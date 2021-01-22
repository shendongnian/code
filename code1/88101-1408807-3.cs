    [TestMethod]
    public void TimeoutExpires()
    {
        var processor = new Processor();
        var mock = new TimeoutMock();
        mock.TimeoutExpired = true;
        processor.Process(mock);
    }
