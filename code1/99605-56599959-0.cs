        private float SubtractWeekend(DateTime start, DateTime end) {
			float totaldays = (end.Date - start.Date).Days;
            var iterationVal = totalDays;
            for (int i = 0; i <= iterationVal; i++) {
                int dayVal = (int)start.Date.AddDays(i).DayOfWeek;
                if(dayVal == 6 || dayVal == 0) {
                    // saturday or sunday
                    totalDays--;
                }
            }
            return totalDays;
        }
