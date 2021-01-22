        static List<long> PrimeNumbers = new List<long>();
        static void Main(string[] args)
        {
            PrimeNumbers.Add(2);
            PrimeNumbers.Add(3);
            PrimeNumbers.Add(5);
            PrimeNumbers.Add(7);
            for (long i = 11; i < 10000000; i += 2)
            {
                if (i % 5 != 0)
                    if (IsPrime(i))
                        PrimeNumbers.Add(i);
            }
        }
        static bool IsPrime(long number)
        {
            foreach (long i in PrimeNumbers)
            {
                if (i <= Math.Sqrt(number))
                {
                    if (number % i == 0)
                        return false;
                }
                else
                    break;
            }
            return true;
        }
