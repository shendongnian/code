    [Test]
    public void TestingAsyncCalc()
    {
        var mocks = new MockRepository();
        var fakeCalc = mocks.DynamicMock<ICalc>();
    
        using (mocks.Record())
        {
            fakeCalc.AddNumbers(1, 2);
            LastCall.Return(3);
        }
    
        var asyncCalc = new AsyncCalc(fakeCalc);
        var completion = new ManualResetEvent(false);
        int result = 0;
        asyncCalc.AddNumbers(1, 2, r => { result = r; completion.Set(); });
        completion.WaitOne();
        Assert.AreEqual(3, calcResult);
    }
    // ** USING AN ANONYMOUS METHOD INSTEAD
    // public void TestResultProcessor(int result)
    // {
    //     Assert.AreEqual(3, result);
    // }
