    [Test]
    public void TestWithoutRaceCondition()
    {
        bool called = false;
        var thread = new Thread(() => called = true);
        thread.Start();
        thread.Join()
        Assert.IsTrue(called);
    }
