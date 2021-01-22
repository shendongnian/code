    [TestMethod]
    public void EveryWriteablePropertyImpementsINotifyPropertyChangedCorrect()
    {
        var viewModel = new TestMyClassWithINotifyPropertyChangedInterface();
        Assert.AreEqual(true, NotificationTester.Verify(viewModel));
    }
