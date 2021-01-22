    public IEnumerable<long> GetPrimes(int max)
    {
        var nonprimes = new bool[max + 1];
    
        for (long i = 2; i <= max; i++)
        {
            if (nonprimes[i] == false)
            {
                for (var j = i * i; j <= max; j += i)
                {
                    nonprimes[j] = true;
                }
    
                yield return i;
            }
        }
    }
