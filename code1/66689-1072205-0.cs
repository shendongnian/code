    public static List<int> GeneratePrimesNaive(int n)
    {
        List<int> primes = new List<int>();
        primes.Add(2);
        int nextPrime = 3;
        while (primes.Count < n)
        {
            int sqrt = (int)Math.Sqrt(nextPrime);
            bool isPrime = true;
            for (int i = 0; (int)primes[i] <= sqrt; i++)
            {
                if (nextPrime % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primes.Add(nextPrime);
            }
            nextPrime += 2;
        }
        return primes;
    }
