    [TestMethod()]
    public void SerieConstructorTest()
    {
        double[] xa = { 2, 3 };
        double[] ya = { 1, 2 };
        double[] xb = { 2, 3 };
        double[] yb = { 1, 2 };
        var A = new Serie_Accessor<double>(xa, ya);
        var B = new Serie_Accessor<double>(xb, yb);
        CollectionAssert.AreEqual(A.X, B.X);
        CollectionAssert.AreEqual(A.Y, B.Y);
    }
