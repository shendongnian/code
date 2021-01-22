    [TestMethod]
    public void TestPersonHistoryItem() {
        DateTime startDate = new DateTime(2001, 2, 2);
        DateTime endDate = new DateTime(2010, 2, 2);
        IComparable phi1 = new PersonHistoryItem(startDate,endDate);
        IComparable phi2 = new PersonHistoryItem(startDate, endDate);
        Assert.IsTrue(phi1.CompareTo(phi2)==0);
    }
