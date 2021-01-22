    IEnumerable<uint> FindPrimes(uint startAt, uint maxCount)
    {
        for (var i = 0UL; i < maxCount; i++)
        {
            startAt = NextPrime(startAt);
            yield return startAt;
        }
        Debug.WriteLine("All the primes were found.");
    }
