    // Simple comparison
    Assert.AreEqual(1, new DateTime(2014, 1, 1).GetTotalMonthsFrom(new DateTime(2014, 2, 1)));
    // Just under 1 month's diff
    Assert.AreEqual(0, new DateTime(2014, 1, 1).GetTotalMonthsFrom(new DateTime(2014, 1, 31)));
    // Just over 1 month's diff
    Assert.AreEqual(1, new DateTime(2014, 1, 1).GetTotalMonthsFrom(new DateTime(2014, 2, 2)));
    // 31 Jan to 28 Feb
    Assert.AreEqual(1, new DateTime(2014, 1, 31).GetTotalMonthsFrom(new DateTime(2014, 2, 28)));
    // Leap year 29 Feb to 29 Mar
    Assert.AreEqual(1, new DateTime(2012, 2, 29).GetTotalMonthsFrom(new DateTime(2012, 3, 29)));
    // Whole year minus a day
    Assert.AreEqual(11, new DateTime(2012, 1, 1).GetTotalMonthsFrom(new DateTime(2012, 12, 31)));
    // Whole year
    Assert.AreEqual(12, new DateTime(2012, 1, 1).GetTotalMonthsFrom(new DateTime(2013, 1, 1)));
    // 29 Feb (leap) to 28 Feb (non-leap)
    Assert.AreEqual(12, new DateTime(2012, 2, 29).GetTotalMonthsFrom(new DateTime(2013, 2, 28)));
    // 100 years
    Assert.AreEqual(1200, new DateTime(2000, 1, 1).GetTotalMonthsFrom(new DateTime(2100, 1, 1)));
    // Same date
    Assert.AreEqual(0, new DateTime(2014, 8, 5).GetTotalMonthsFrom(new DateTime(2014, 8, 5)));
    // Past date
    Assert.AreEqual(6, new DateTime(2012, 1, 1).GetTotalMonthsFrom(new DateTime(2011, 6, 10)));
