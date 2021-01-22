        public int[] getMonth(int weekNum, int year)
        {
	        DateTime StartYear = new DateTime(year, 1, 1);
	        System.DayOfWeek StartDOW = StartYear.DayOfWeek;
	        DateTime DayOfYearWeekStart = default(DateTime);
	        DateTime DayOfYearWeekEnd = default(DateTime);
	        int x = 0;
	        if ((StartDOW == System.DayOfWeek.Sunday)) {
		        DayOfYearWeekStart = StartYear.AddDays((weekNum - 1) * 7);
		        DayOfYearWeekEnd = DayOfYearWeekStart.AddDays(6);
	        } else {
		        for (x = 0; x <= 7; x += 1) {
			        if (StartYear.AddDays(x).DayOfWeek == DayOfWeek.Sunday) {
				        break; // TODO: might not be correct. Was : Exit For
			        }
		        }
		        if (weekNum == 1) {
			        DayOfYearWeekStart = StartYear;
			        DayOfYearWeekEnd = StartYear.AddDays(x - 1);
		        } else if (weekNum > 1) {
			        DayOfYearWeekStart = StartYear.AddDays(((weekNum - 2) * 7) + x);
			        DayOfYearWeekEnd = DayOfYearWeekStart.AddDays(6);
		        }
	        }
	        int[] Month = new int[2];
	        Month[0] = DayOfYearWeekStart.Month;
	        Month[1] = DayOfYearWeekEnd.Month;
	        return Month;
        }
