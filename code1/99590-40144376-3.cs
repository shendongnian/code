    [TestMethod]
    public void TestGetBusinessTimespanBetween()
    {
        var workdayStart = new TimeSpan(8, 0, 0);
        var workdayEnd = new TimeSpan(17, 0, 0);
        var holidays = new List<DateTime>()
        {
            new DateTime(2018, 1, 15), // a Monday
            new DateTime(2018, 2, 15) // a Thursday
        };
        var testdata = new[]
        {
            new
            {
                expectedMinutes = 0,
                start = new DateTime(2016, 10, 19, 9, 50, 0),
                end = new DateTime(2016, 10, 19, 9, 50, 0)
            },
            new
            {
                expectedMinutes = 10,
                start = new DateTime(2016, 10, 19, 9, 50, 0),
                end = new DateTime(2016, 10, 19, 10, 0, 0)
            },
            new
            {
                expectedMinutes = 5,
                start = new DateTime(2016, 10, 19, 7, 50, 0),
                end = new DateTime(2016, 10, 19, 8, 5, 0)
            },
            new
            {
                expectedMinutes = 5,
                start = new DateTime(2016, 10, 19, 16, 55, 0),
                end = new DateTime(2016, 10, 19, 17, 5, 0)
            },
            new
            {
                expectedMinutes = 15,
                start = new DateTime(2016, 10, 19, 16, 50, 0),
                end = new DateTime(2016, 10, 20, 8, 5, 0)
            },
            new
            {
                expectedMinutes = 10,
                start = new DateTime(2016, 10, 19, 16, 50, 0),
                end = new DateTime(2016, 10, 20, 7, 55, 0)
            },
            new
            {
                expectedMinutes = 5,
                start = new DateTime(2016, 10, 19, 17, 10, 0),
                end = new DateTime(2016, 10, 20, 8, 5, 0)
            },
            new
            {
                expectedMinutes = 0,
                start = new DateTime(2016, 10, 19, 17, 10, 0),
                end = new DateTime(2016, 10, 20, 7, 5, 0)
            },
            new
            {
                expectedMinutes = 545,
                start = new DateTime(2016, 10, 19, 12, 10, 0),
                end = new DateTime(2016, 10, 20, 12, 15, 0)
            },
            // Spanning multiple weekdays
            new
            {
                expectedMinutes = 835,
                start = new DateTime(2016, 10, 19, 12, 10, 0),
                end = new DateTime(2016, 10, 21, 8, 5, 0)
            },
            // Spanning multiple weekdays
            new
            {
                expectedMinutes = 1375,
                start = new DateTime(2016, 10, 18, 12, 10, 0),
                end = new DateTime(2016, 10, 21, 8, 5, 0)
            },
            // Spanning from a Thursday to a Tuesday, 5 mins short of complete day.
            new
            {
                expectedMinutes = 1615,
                start = new DateTime(2016, 10, 20, 12, 10, 0),
                end = new DateTime(2016, 10, 25, 12, 5, 0)
            },
            // Spanning from a Thursday to a Tuesday, 5 mins beyond complete day.
            new
            {
                expectedMinutes = 1625,
                start = new DateTime(2016, 10, 20, 12, 10, 0),
                end = new DateTime(2016, 10, 25, 12, 15, 0)
            },
            // Spanning from a Friday to a Monday, 5 mins beyond complete day.
            new
            {
                expectedMinutes = 545,
                start = new DateTime(2016, 10, 21, 12, 10, 0),
                end = new DateTime(2016, 10, 24, 12, 15, 0)
            },
            // Spanning from a Friday to a Monday, 5 mins short complete day.
            new
            {
                expectedMinutes = 535,
                start = new DateTime(2016, 10, 21, 12, 10, 0),
                end = new DateTime(2016, 10, 24, 12, 5, 0)
            },
            // Spanning from a Saturday to a Monday, 5 mins short complete day.
            new
            {
                expectedMinutes = 245,
                start = new DateTime(2016, 10, 22, 12, 10, 0),
                end = new DateTime(2016, 10, 24, 12, 5, 0)
            },
            // Spanning from a Saturday to a Sunday, 5 mins beyond complete day.
            new
            {
                expectedMinutes = 0,
                start = new DateTime(2016, 10, 22, 12, 10, 0),
                end = new DateTime(2016, 10, 23, 12, 15, 0)
            },
            // Times within the same Saturday.
            new
            {
                expectedMinutes = 0,
                start = new DateTime(2016, 10, 22, 12, 10, 0),
                end = new DateTime(2016, 10, 23, 12, 15, 0)
            },
            // Spanning from a Saturday to the Sunday next week.
            new
            {
                expectedMinutes = 2700,
                start = new DateTime(2016, 10, 22, 12, 10, 0),
                end = new DateTime(2016, 10, 30, 12, 15, 0)
            },
            // Spanning a year.
            new
            {
                expectedMinutes = 143355,
                start = new DateTime(2016, 10, 22, 12, 10, 0),
                end = new DateTime(2017, 10, 30, 12, 15, 0)
            },
            // Spanning a year with 2 holidays.
            new
            {
                expectedMinutes = 142815,
                start = new DateTime(2017, 10, 22, 12, 10, 0),
                end = new DateTime(2018, 10, 30, 12, 15, 0)
            },
        };
        foreach (var item in testdata)
        {
            Assert.AreEqual(item.expectedMinutes,
                DateHelper.GetBusinessTimespanBetween(
                    item.start, item.end,
                    workdayStart, workdayEnd,
                    holidays)
                    .TotalMinutes);
        }
    }
