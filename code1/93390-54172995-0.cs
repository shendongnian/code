    class CheckIfPrime
       {
        static void Main()
          {
              while (true)
            {
                Console.Write("Enter a number: ");
                decimal a = decimal.Parse(Console.ReadLine());
                decimal[] k = new decimal[int.Parse(a.ToString())];
                decimal p = 0;
                for (int i = 2; i < a; i++)
                {
                    if (a % i != 0)
                    {
                        p += i;
                        k[i] = i;
                    }
                    else
                        p += i;
                }
                if (p == k.Sum())
                   { Console.WriteLine ("{0} is prime!", a);}
                else
                   {Console.WriteLine("{0} is NOT prime", a);}
            }
        }
    }
