    [Test]
    public void TestWithRaceCondition()
    {
        bool called = false;
        new Thread(() => called = true).Start();
        Assert.IsTrue(called);
    }
