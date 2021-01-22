        private Double GetTotalMonths(DateTime future, DateTime past)
        {
            Double totalMonths = 0.0;
            while ((future - past).TotalDays > 28 )
            {
                past = past.AddMonths(1);
                totalMonths += 1;
            }
            
            var daysInCurrent = DateTime.DaysInMonth(future.Year, future.Month);
            var remaining = future.Day - past.Day;
            totalMonths += ((Double)remaining / (Double)daysInCurrent);
            return totalMonths;
        }
