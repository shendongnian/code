    public static void TestMethodUsingRandom()
    {
        double d = new Random().NextDouble();
        Contract.Assume(d <= 1.0);
        Contract.Assert(d >= 0.0);
        Contract.Assert(d <= 4.0);
    }
