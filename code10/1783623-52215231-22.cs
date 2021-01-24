    [Test("ParallelLock", "", true)]
    public BigInteger Test1(string input, int scale)
    {
       BigInteger result = 0;
       object sync = new object();
    
       Parallel.For(
          0,
          input.Length,
          x =>
             {
                var temp = BigInteger.Pow(95, x) * (input[x] - 32);
                lock (sync)
                   result += temp;
             });
    
       return result;
    }
