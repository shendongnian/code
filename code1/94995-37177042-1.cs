    public bool IsPrimeNumber(int val) {
        // Using Sieve of Eratosthenes.
        if (val < 2)
        {
            return false;
        }
        
        // Reserve place for val + 1 and set with true.
        var mark = new bool[val + 1];
        for(var i = 2; i <= val; i++)
        {
            mark[i] = true;
        }
        
        // Iterate from 2 ... sqrt(val).
        for (var i = 2; i <= Math.Sqrt(val); i++)
        {
            if (mark[i])
            {
                // Cross out every i-th number in the places after i (all the multiples of i).
                for (var j = (i * i); j <= val; j += i)
                {
                    mark[j] = false;
                }
            }
        }
        
        return mark[val];
    }
