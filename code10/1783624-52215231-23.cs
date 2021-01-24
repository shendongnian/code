    [Test("ParallelResult", "", false)]
    public BigInteger Test2(string input, int scale)
    {
       BigInteger result = 0;
       object sync = new object();
       Parallel.For(
          0,
          input.Length,
          () => new BigInteger(0),
          (x, state, subTotal) => subTotal + BigInteger.Pow(95, x) * (input[x] - 32),
          integer =>
             {
                lock (sync)
                   result += integer;
             });
       return result;
    }
