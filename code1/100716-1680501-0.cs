    [TestMethod]
    public void CheckInSetsCheckedOutStatusToFalse()
    {
        // arrange - create a checked out item
        Content c = new Content();
        c.CheckOut();
        // act - check it in
        c.CheckIn();
        // assert - IsCheckedOut should be set back to false
        Assert.AreEqual(false, c.IsCheckedOut);
    }
