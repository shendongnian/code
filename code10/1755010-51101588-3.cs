    var dates = new List<DateTime>
    {
        Convert.ToDateTime("29/06/2018 10:00"),
        Convert.ToDateTime("29/06/2018 10:05")
    };
    var replayDate = Convert.ToDateTime("29/06/2018 13:00");
    // process the offset once (before the loop) -- here it will be 3 hours
    var offset = replayDate.TimeOfDay - dates[0].TimeOfDay;
    for (var index = 0; index < dates.Count; index++)
    {
        // shift all your dates by that offset
        dates[index] = dates[index].Add(offset);
    }
    Assert.AreEqual(Convert.ToDateTime("29/06/2018 13:00"), dates[0]);
    Assert.AreEqual(Convert.ToDateTime("29/06/2018 13:05"), dates[1]);
