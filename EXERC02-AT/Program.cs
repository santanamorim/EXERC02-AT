using System;

abstract class Conta
{
    protected decimal _saldo;

    private decimal _limite;

    public decimal Saldo => _saldo;

    public decimal Limite
    {
        get => _limite;
        set
        {
            if (value >= 0)
            {
                _limite = value;
            }
            else
            {
                Console.WriteLine("O limite não pode ser negativo.");
            }
        }
    }

    public abstract void Depositar(decimal valor);
    public abstract void Sacar(decimal valor);
}

class ContaCorrente : Conta
{
    private decimal _limite;

    public ContaCorrente(decimal limite)
    {
        _saldo = 0;
        Limite = limite;
    }

    public override void Depositar(decimal valor)
    {
        _saldo += valor;
        Console.WriteLine($"Depositado com sucesso: R${valor}");
    }

    public override void Sacar(decimal valor)
    {
        if (_saldo + _limite >= valor)
        {
            _saldo -= valor;
            Console.WriteLine($"Sacado com sucesso: R${valor}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para saque.");
        }
    }
}

class Program
{
    static void Main()
    {
        ContaCorrente conta = new ContaCorrente(1000);

        int opcao;
        decimal valor;

        do
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1. Sacar");
            Console.WriteLine("2. Apresentar o saldo");
            Console.WriteLine("3. Depositar");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o valor a sacar: ");
                    if (decimal.TryParse(Console.ReadLine(), out valor))
                    {
                        conta.Sacar(valor);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 2:
                    Console.WriteLine($"Saldo atual: R${conta.Saldo}");
                    break;

                case 3:
                    Console.Write("Digite o valor a depositar: ");
                    if (decimal.TryParse(Console.ReadLine(), out valor))
                    {
                        conta.Depositar(valor);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Saindo do programa.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 4);
    }
}