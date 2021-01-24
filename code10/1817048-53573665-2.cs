    public static DateTime NextSunday(DateTime aDate)
            {
            
                if (aDate.DayOfWeek.ToString() == "Monday") { return aDate.AddDays(6); }
                else if (aDate.DayOfWeek.ToString() == "Tuesday") { return aDate.AddDays(5); }
                else if (aDate.DayOfWeek.ToString() == "Wednesday") { return aDate.AddDays(4); }
                else if (aDate.DayOfWeek.ToString() == "Thursday") { return aDate.AddDays(3); }
                else if (aDate.DayOfWeek.ToString() == "Friday") { return aDate.AddDays(2); }
                else if (aDate.DayOfWeek.ToString() == "Saturday") { return aDate.AddDays(1); }
                else { return aDate; }
            }
