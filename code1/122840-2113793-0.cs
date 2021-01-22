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
        var completion = ManualResetEvent(false);
        int calcResult;
        asyncCalc.AddNumbers(1, 2,
            delegate(int result) {
                calcResult = result;
                resultcompletion.Set();
            });
        completion.WaitOne();
        Assert.AreEqual(3, calcResult);
    }
