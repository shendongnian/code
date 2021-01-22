    static IEnumerable<int> Primes(int count)
    {
        return Primes().Take(count);
    }
    
    static IEnumerable<int> Primes()
    {
        List<int> cache = new List<int>();
    
        var primes = Enumerable.Range(2, int.MaxValue - 2).Select(candidate => new 
        {
            Sqrt = (int)Math.Sqrt(candidate), // caching sqrt for performance
            Current = candidate
        }).Where(candidate => !cache.TakeWhile(c => c <= candidate.Sqrt)
                .Any(cachedPrime => candidate.Current % cachedPrime == 0))
                .Select(p => p.Current);
    
        foreach (var prime in primes)
        {
            cache.Add(prime);
            yield return prime;
        }
    }
