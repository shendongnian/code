    [Test("AsParallel", "", false)]
    public BigInteger Test4(string input, int scale)
    {
       return Enumerable.Range(0, input.Length)
                        .AsParallel()
                        .Aggregate(
                            new BigInteger(0),
                            (subtotal, x) => subtotal + BigInteger.Pow(95, x) * (input[x] - 32),
                            (total, thisThread) => total + thisThread,
                            (finalSum) => finalSum);;
    }
