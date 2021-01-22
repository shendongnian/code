    IEnumerable<uint> FindPrimes(uint startAt, uint maxCount, int maxMinutes)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (var i = 0UL; i < maxCount; i++)
        {
            startAt = NextPrime(startAt);
            yield return startAt;
            
            if (sw.Elapsed.TotalMinutes > maxMinutes)
                yield break;
        }
        Debug.WriteLine("All the primes were found.");
    }
