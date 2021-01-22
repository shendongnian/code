            private int CountDays(DayOfWeek day, DateTime startDate, DateTime endDate)
            {
                int dayCount = 0;
    
                for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
                {
                    if (dt.DayOfWeek == day)
                    {
                        dayCount++;
                    }
                }
    
                return dayCount;
            }
