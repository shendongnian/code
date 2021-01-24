    public static int CacheSize
    {
        [__DynamicallyInvokable] get
        {
            return Regex.cacheSize;
        }
        
        [__DynamicallyInvokable] set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof (value));
            Regex.cacheSize = value;
            if (Regex.livecode.Count <= Regex.cacheSize)
                return;
            lock (Regex.livecode)
            {
                while (Regex.livecode.Count > Regex.cacheSize)
                    Regex.livecode.RemoveLast();
            }
        }
    }
