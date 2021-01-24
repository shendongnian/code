    using System;
    
    namespace IsPrime
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                string isPlaying = "y";
                bool isPrime;
    
                while(isPlaying == "y")
                {
                    var timer = System.Diagnostics.Stopwatch.StartNew ();
                    isPrime = IsPrime(9389274937501454911);
                    if (isPrime)
                    {
                        Console.WriteLine(9389274937501454911 + " is Prime");
                    }
                    else 
                        Console.WriteLine(9389274937501454911 + " is not prime");
    
                    isPrime = IsPrime(7389274937501454911);
                    if (isPrime)
                    {
                        Console.WriteLine(7389274937501454911 + " is Prime");
                    }
                    else 
                        Console.WriteLine(7389274937501454911 + " is not prime");
                    timer.Stop ();
                    var time = timer.ElapsedMilliseconds;
                    Console.WriteLine("Elasped Time: " + time + "\n");
    
                    Console.WriteLine("Do you want to play again?: y / n");
                    isPlaying = Console.ReadLine ();
    
                }
            }
    
            public static bool IsPrime(ulong number)
            {
                if (number == 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
               //This returns the whole number greater than or equal to the specified number, and in this case
               //In this case, I take the square root, obvious to divide in half, so the variable i increases twice, since I'm working with the biggest number and divided in half
                var boundary = (ulong)Math.Floor(Math.Sqrt(number));
    
                for (ulong i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0) return false;
                }
    
                return true;
            }
        }
    }
