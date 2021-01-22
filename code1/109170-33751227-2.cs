        [TestMethod()]
        public void TestWeekdayCount()
        {
            var init = new DateTime(2000, 01, 01);
            for (int day = 0; day < 7; day++)
            {
                var dayOfWeek = (DayOfWeek)day;
                for (int shift = 0; shift < 8; shift++)
                {
                    for (int i = 0; i < 365; i++)
                    {
                        var begin = init.AddDays(shift);
                        var end = init.AddDays(shift + i);
                        var count1 = GetWeekdayCount(dayOfWeek, begin, end);
                        var count2 = GetWeekdayCountStupid(dayOfWeek, begin, end);
                        Assert.AreEqual(count1, count2);
                    }
                }
            }
        }
