    using System;
					
        public class Program
        {
	     static void Mostra(double n, double p, double q)
         {
        //double res = n + ((n * (p / 100)) * q);
		
        Console.WriteLine("Crescimento da dívida ao longo de " + q.ToString() + " anos: \n");
		
		//Loop that increments each year for q number of years
		for (int x = 0; x < q + 1; x++)
		{
			double res = 0;
			res = n + ((n * (p / 100)) * x);
			Console.WriteLine(res);
		}
    }
    static double Validar(string s)
    {
		int x = int.Parse(s);
		double res = (double)(x);
		
		return res;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Insira o valor do seu empréstimo em euros:");
        string s1 = Console.ReadLine();
        Console.WriteLine("Insira o valor correspondente à taxa de juro acordada:");
        string s2 = Console.ReadLine();
        Console.WriteLine("Insira o número de anos em que a dívida não foi paga:");
        string s3 = Console.ReadLine();
        double n = Validar(s1);
        double p = Validar(s2);
        double q = Validar(s3);
		if (n >= 0 && p >= 0 && q >= 0 && p <= 100)
		{
			Mostra(n, p, q);
		}
		else
			Console.WriteLine("O valor introduzido é inválido.");
    }
    }
