    [TestMethod]
    public void TestAge()
    {
        string age = HowOld(new DateTime(2011, 1, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("1 year", age);
        age = HowOld(new DateTime(2011, 11, 30), new DateTime(2012, 11, 30));
        Assert.AreEqual("1 year", age);
        age = HowOld(new DateTime(2001, 1, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("11 years", age);
        age = HowOld(new DateTime(2012, 1, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("10 months", age);
        age = HowOld(new DateTime(2011, 12, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("11 months", age);
        age = HowOld(new DateTime(2012, 10, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("1 month", age);
        age = HowOld(new DateTime(2008, 2, 28), new DateTime(2009, 2, 28));
        Assert.AreEqual("1 year", age);
        age = HowOld(new DateTime(2008, 3, 28), new DateTime(2009, 2, 28));
        Assert.AreEqual("11 months", age);
        age = HowOld(new DateTime(2008, 3, 28), new DateTime(2009, 3, 28));
        Assert.AreEqual("1 year", age);
        age = HowOld(new DateTime(2009, 1, 28), new DateTime(2009, 2, 28));
        Assert.AreEqual("1 month", age);
        age = HowOld(new DateTime(2009, 2, 1), new DateTime(2009, 3, 1));
        Assert.AreEqual("1 month", age);
        // NOTE.
        // new DateTime(2008, 1, 31).AddMonths(1) == new DateTime(2009, 2, 28);
        // new DateTime(2008, 1, 28).AddMonths(1) == new DateTime(2009, 2, 28);
        age = HowOld(new DateTime(2009, 1, 31), new DateTime(2009, 2, 28));
        Assert.AreEqual("4 weeks", age);
        age = HowOld(new DateTime(2009, 2, 1), new DateTime(2009, 2, 28));
        Assert.AreEqual("3 weeks", age);
        age = HowOld(new DateTime(2009, 2, 1), new DateTime(2009, 3, 1));
        Assert.AreEqual("1 month", age);
        age = HowOld(new DateTime(2012, 11, 5), new DateTime(2012, 11, 30));
        Assert.AreEqual("3 weeks", age);
        age = HowOld(new DateTime(2012, 11, 1), new DateTime(2012, 11, 30));
        Assert.AreEqual("4 weeks", age);
        age = HowOld(new DateTime(2012, 11, 20), new DateTime(2012, 11, 30));
        Assert.AreEqual("1 week", age);
        age = HowOld(new DateTime(2012, 11, 25), new DateTime(2012, 11, 30));
        Assert.AreEqual("5 days", age);
        age = HowOld(new DateTime(2012, 11, 29), new DateTime(2012, 11, 30));
        Assert.AreEqual("1 day", age);
        age = HowOld(new DateTime(2012, 11, 30), new DateTime(2012, 11, 30));
        Assert.AreEqual("just born", age);
        age = HowOld(new DateTime(2000, 2, 29), new DateTime(2009, 2, 28));
        Assert.AreEqual("8 years", age);
        age = HowOld(new DateTime(2000, 2, 29), new DateTime(2009, 3, 1));
        Assert.AreEqual("9 years", age);
        Exception e = null;
        try
        {
            age = HowOld(new DateTime(2012, 12, 1), new DateTime(2012, 11, 30));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            e = ex;
        }
        Assert.IsTrue(e != null);
    }
