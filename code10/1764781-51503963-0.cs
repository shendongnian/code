    [TestMethod]
    public void Test1()
    {
        int nFails = 0;
        foreach (var src in testDataSetFiles)
        {
            if (someMethodForTest(src) == null)
            {
                nFails++:
            }
        }
    
        Assert.IsTrue(nFails == 0);
    }
