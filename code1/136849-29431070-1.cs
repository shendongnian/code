    [TestMethod]
    public void Today()
    {
        SystemClock.Set(new DateTime(2015, 4, 3));
        DateTime expectedDay = new DateTime(2015, 4, 2);
        DateTime yesterday = SystemClock.Today.AddDays(-1D);
        Assert.AreEqual(expectedDay, yesterday);
        SystemClock.Reset();
    }
