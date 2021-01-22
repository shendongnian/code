    [Test] 
    public void CreateName_AddsCurrentTimeAtEnd() 
    {
        using (Clock.NowIs(new DateTime(2010, 12, 31, 23, 59, 00)))
        {
            string name = new ReportNameService().CreateName(...);
            Assert.AreEqual("name 2010-12-31 23:59:00", name);
        } 
    }
