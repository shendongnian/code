    static IEnumerable<int> Primes(int count)
    {
        return Primes().Take(count);
    }
    
    static IEnumerable<int> Primes()
    {
        List<int> cache = new List<int>();
    
        var primes = Enumerable.Range(2, int.MaxValue - 2)
            .Where(candidate => !cache.TakeWhile(c => c <= (int)Math.Sqrt(candidate))
                .Any(cachedPrime => candidate % cachedPrime == 0));
    
        foreach (var prime in primes)
        {
            cache.Add(prime);
            yield return prime;
        }
    }
