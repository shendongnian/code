     public enum NonWorkingDays { SaturdaySunday = 0, FridaySaturday = 1 };
            public int getBusinessDates(DateTime dateSt, DateTime dateNd, NonWorkingDays nonWorkingDays = NonWorkingDays.SaturdaySunday)
            {
                List<DateTime> datelist = new List<DateTime>();
                while (dateSt.Date < dateNd.Date)
                {
                    datelist.Add((dateSt = dateSt.AddDays(1)));
                }
                if (nonWorkingDays == NonWorkingDays.SaturdaySunday)
                {
                    return datelist.Count(d => d.DayOfWeek != DayOfWeek.Saturday &&
                           d.DayOfWeek != DayOfWeek.Friday);
                }
                else
                {
                    return datelist.Count(d => d.DayOfWeek != DayOfWeek.Friday &&
                           d.DayOfWeek != DayOfWeek.Saturday);
                }
            }
