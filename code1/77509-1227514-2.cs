    // generate every prime number
    public IEnumerator<int> GetPrimeEnumerator()
    {
        yield return 2;
        var primes = new List<int>();
        primesSoFar.Add(2);
        Func<int, bool> IsPrime = n => primes.TakeWhile(
            p => p <= (int)Math.Sqrt(n)).FirstOrDefault(p => n % p == 0) == 0;
    
        for (int i = 3; true; i += 2)
        {
            if (IsPrime(i))
            {
                yield return i;
                primes.Add(i);
            }
        }
    }
