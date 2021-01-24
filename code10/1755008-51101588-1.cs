    var dates = new List<DateTime>
    {
        Convert.ToDateTime("29/06/2018 10:00"),
        Convert.ToDateTime("29/06/2018 10:05")
    };
    var replayDate = Convert.ToDateTime("29/06/2018 13:00");
    var offset = replayDate.TimeOfDay - dates[0].TimeOfDay;
    for (var index = 0; index < dates.Count; index++)
    {
        dates[index] = dates[index].Add(offset);
    }
    Assert.AreEqual(Convert.ToDateTime("29/06/2018 13:00"), dates[0]);
    Assert.AreEqual(Convert.ToDateTime("29/06/2018 13:05"), dates[1]);
