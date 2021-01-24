    [TestMethod]
    public void TestLogs()
    {
        LogManager lm = new LogManager();
        int a = 0;
        lm.LogMinimal(a++.ToString());
        // ...
        lm.Dispose();
    }
