    public static void TestMethod()
    {
        double d = MethodReturningDouble();
        Contract.Assert(d >= 0.0);
        Contract.Assert(d <= 4.0);
    }
    public static double MethodReturningDouble()
    {
      //  Contract.Ensures(Contract.Result<double>() <= 4.0); // <- without this line the above asserts are unproven
        return 3.0;
    }
