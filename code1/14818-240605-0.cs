    [Test]
    public void Test()
    {
       DateTime sunday = DateTime.Parse("10/26/2008");
       DateTime nextSunday = DateTime.Parse("11/2/2008");
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/21/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/22/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/23/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/24/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/25/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/26/2008")));
       Assert.AreEqual(sunday, GetSunday(DateTime.Parse("10/27/2008 10:59 AM")));
       Assert.AreEqual(nextSunday, GetSunday(DateTime.Parse("10/27/2008 11:00 AM")));
    }
    private DateTime GetSunday(DateTime date)
    {
       if (date.DayOfWeek == DayOfWeek.Monday && date.Hour < 11)
          return date.Date.AddDays(-1);
       while (date.DayOfWeek != DayOfWeek.Sunday)
          date = date.AddDays(1);
       return date.Date;
    }
