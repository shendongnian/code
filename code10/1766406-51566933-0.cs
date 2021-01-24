    private double Compute(double a, double b, double c)
    {
        /*         check if a, b and c are integers         int if true          double if false    */
        return (a % 1 == 0 && b % 1 == 0 && c % 1 == 0) ? (a + b + c) / 3 : ((a + b + c) / 3.0) / 209;
    }
    [TestMethod()]
    public void Int()
    {
        int a = 1;
        int b = 2;
        int c = 3;
        int result = (int)Compute(a, b, c);
        int expected = (1 + 2 + 3) / 3;
        Assert.AreEqual(expected, result);
    }
    [TestMethod()]
    public void Double()
    {
        double a = 1.1;
        double b = 2.2;
        double c = 3.3;
        double result = Compute(a, b, c);
        double expected = ((1.1 + 2.2 + 3.3) / 3.0) / 209;
        Assert.AreEqual(expected, result);
    }
