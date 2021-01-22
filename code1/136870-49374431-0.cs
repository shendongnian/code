    [TestMethod]
    public void it_should_make_time_move_faster()
    {
        int speedOfTimePerMs = 1000;
        int timeToPassMs = 3000;
        int expectedElapsedVirtualTime = speedOfTimePerMs * timeToPassMs;
        DateTime whenTimeStarts = DateTime.Now;
        ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
        Thread.Sleep(timeToPassMs);
        DateTime expectedTime = DateTime.Now.AddMilliseconds(expectedElapsedVirtualTime - timeToPassMs);
        DateTime virtualTime = time.Now;
        Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs));
    }
