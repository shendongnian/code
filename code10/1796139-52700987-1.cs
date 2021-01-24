            int primes = 0;
            Console.WriteLine("Enter a number");
            int N = int.Parse(Console.ReadLine());
            for (int i = 2; i <= N; i++)
            {
               bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }  
    
                }
                if (isPrime)
                {
                    Console.WriteLine(i + " is a prime number");
                    primes++;
                }
            }
            Console.WriteLine("Between 1 to " + N + " there are " + primes + " prime numbers");
