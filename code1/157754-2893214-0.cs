    [Test()]
	public void TestCaseWorks ()
	{
		string format = "ddd MMM dd HH:mm:ss UTCzzzzz yyyy";
        string temp = "Sun May 23 22:00:00 UTC+0300 2010";
        DateTime time = DateTime.ParseExact(temp, format, CultureInfo.InvariantCulture);
        
        Assert.AreEqual(DayOfWeek.Sunday, time.DayOfWeek);
        Assert.AreEqual(5, time.Month);
        Assert.AreEqual(23, time.Day);
        Assert.AreEqual(0, time.Minute);
        Assert.AreEqual(0, time.Second);
        Assert.AreEqual(2010, time.Year);
        // Below is the only actually useful assert -- making sure the
        // timezone was parsed correctly.
        // In my case, I am GMT-0700, the target time is GMT+0300 so
        // 22 + (-7 - +3) = 12 is the expected answer. It is an exercise
        // for the reader to make a robust test that will work in any
        // timezone ;).
        Assert.AreEqual(12, time.Hour);
    }
