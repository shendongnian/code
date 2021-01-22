    // Just under 1 month's diff
    Assert.AreEqual(0, new DateTime(2014, 1, 1).MonthsBefore(new DateTime(2014, 1, 31)));
    // Just over 1 month's diff
    Assert.AreEqual(1, new DateTime(2014, 1, 1).MonthsBefore(new DateTime(2014, 2, 2)));    
    // Past date returns NEGATIVE
    Assert.AreEqual(-6, new DateTime(2012, 1, 1).MonthsBefore(new DateTime(2011, 6, 10)));
