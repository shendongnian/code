    [TestMethod]
    public void EveryWriteablePropertyImplementsINotifyPropertyChangedCorrect()
    {
        var viewModel = new TestMyClassWithINotifyPropertyChangedInterface();
        Assert.AreEqual(true, NotificationTester.Verify(viewModel));
    }
