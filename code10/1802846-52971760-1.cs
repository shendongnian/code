            var from = DateTime.Parse("10/24/2018");
            var to = DateTime.Parse("11/14/2018");
            var dayList = new List<DateTime>();
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
            {
                if
                (
                    day.DayOfWeek == DayOfWeek.Monday ||
                    day.DayOfWeek == DayOfWeek.Wednesday ||
                    day.DayOfWeek == DayOfWeek.Friday ||
                    day.DayOfWeek == DayOfWeek.Sunday
                )
                {
                    dayList.Add(day);
                }
            }
