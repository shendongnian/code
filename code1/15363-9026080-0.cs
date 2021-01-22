    [TestMethod]
    public void ShouldFindFridaysInTimeSpan()
    {
        //reference: http://stackoverflow.com/questions/248273/count-number-of-mondays-in-a-given-date-range
        var spanOfSixtyDays = new TimeSpan(60, 0, 0, 0);
        var setOfDates = new List<DateTime>(spanOfSixtyDays.Days);
        var now = DateTime.Now;
        for(int i = 0; i < spanOfSixtyDays.Days; i++)
        {
            setOfDates.Add(now.AddDays(i));
        }
        Assert.IsTrue(setOfDates.Count == 60,
            "The expected number of days is not here.");
        var fridays = setOfDates.Where(i => i.DayOfWeek == DayOfWeek.Friday);
        Assert.IsTrue(fridays.Count() > 0,
            "The expected Friday days are not here.");
        Assert.IsTrue(fridays.First() == setOfDates.First(i => i.DayOfWeek == DayOfWeek.Friday),
            "The expected first Friday day is not here.");
        Assert.IsTrue(fridays.Last() == setOfDates.Last(i => i.DayOfWeek == DayOfWeek.Friday),
            "The expected last Friday day is not here.");
    }
