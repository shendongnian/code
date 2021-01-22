    [TestMethod]
    public void TestDynamicComparer()
    {
        string lhs = "10";
        string rhs = "10";
        Assert.AreEqual(0, DynamicComparer<int>.Default.Compare(lhs, rhs));
        lhs = "2.0";
        rhs = "3.1";
        // basic equality
        Assert.AreNotEqual(0, DynamicComparer<double>.Default.Compare(lhs, rhs));
        // correct order
        Assert.IsTrue(DynamicComparer<double>.Default.Compare(lhs, rhs) < 0);
        // check two invalid casts are unordered
        Assert.AreEqual(0, DynamicComparer<int>.DefaultNoThrow.Compare(lhs, rhs));
        // real proof it works
        lhs = "9";
        rhs = "09";
        Assert.AreEqual(0, DynamicComparer<int>.Default.Compare(lhs, rhs));
        lhs = "9.0";
        rhs = "09";
        Assert.AreEqual(0, DynamicComparer<double>.Default.Compare(lhs, rhs));
        // test the valid cast is ordered ahead of ("less than") the invalid cast
        Assert.AreNotEqual(0, DynamicComparer<int>.DefaultNoThrow.Compare(lhs, rhs));
        Assert.IsTrue(DynamicComparer<int>.DefaultNoThrow.Compare(lhs, rhs) > 0);
    }
    [TestMethod]
    [ExpectedException(typeof(InvalidCastException))]
    public void TestDynamicComparerInvalidCast()
    {
        // make sure the default comparer throws an InvalidCastException if a cast fails
        string lhs = "2.0";
        string rhs = "3.1";
        DynamicComparer<int>.Default.Compare(lhs, rhs);
    }
