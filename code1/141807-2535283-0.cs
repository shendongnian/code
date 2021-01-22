    static private long maxfactor (long n)
    {
        for (long k = n / 2; k > 1; k--)
        {
            if (n % k == 0 && primo(k))
            {
                return k;
            }
        }
        // no factors found
        return 1;
    }
