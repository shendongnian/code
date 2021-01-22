    [TestMethod]
    public void DateTimeExtensions_Within_WorksWithNullable()
    {
        var now = DateTime.Now;
        var dtNow1 = new DateTime?(now);
        var dtNow2 = new DateTime?(now.AddMilliseconds(1));
        var dtNowish = new DateTime?(now.AddMilliseconds(25));
        DateTime? dtNull = null;
        Assert.IsTrue(now == dtNow1.Within()); // Compare DateTime to DateTime?
        Assert.IsTrue(dtNow1 == dtNow2.Within()); // Compare two DateTime? using a different syntax
        Assert.IsTrue(dtNow1 == dtNow2.Within()); // Same value should be true
        Assert.IsFalse(dtNow1 == dtNowish.Within()); // Outside of the default 10ms tolerance, should not be equal
        Assert.IsTrue(dtNow1 == dtNowish.Within(TimeSpan.FromMilliseconds(50))); // ... but we can override this
        Assert.IsFalse(dtNow1 == dtNull.Within()); // Comparing a value to null should be false
        Assert.IsTrue(dtNull == dtNull.Within()); // ... but two nulls should be true
    }
