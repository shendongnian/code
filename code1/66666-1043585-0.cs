    static IEnumerable<int> Primes(int count)
    {
        return Primes().Take(count);
    }
    
    static IEnumerable<int> Primes()
    {
        List<int> cache = new List<int>();
    
        var primes = Enumerable.Range(2, int.MaxValue - 2).Select(i => new
        {
            Sqrt = (int)Math.Sqrt(i),
            Current = i
        }).Where(i => !cache.TakeWhile(c => c <= i.Sqrt).Any(c => i.Current % c == 0))
        .Select(p => p.Current);
    
        foreach (var prime in primes)
        {
            cache.Add(prime);
            yield return prime;
        }
    }
