            DateTime getDate(string dayOfWeekString)
            {
                var dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeekString);
                var now = DateTime.Now.Date;
                var diff = (7 + (now.DayOfWeek - dayOfWeek)) % 7;
                return now.AddDays(-1 * diff).Date;
            }
            Console.WriteLine(getDate("Tuesday"));
            Console.ReadLine();
