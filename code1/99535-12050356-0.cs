    public double WorkDays(DateTime startDate, DateTime endDate){
			double weekendDays;
			
			double days = endDate.Subtract(startDate).TotalDays;
			
			if(days<0) return 0;
			
			DateTime startMonday = startDate.AddDays(DayOfWeek.Monday - startDate.DayOfWeek).Date;
			DateTime endMonday = endDate.AddDays(DayOfWeek.Monday - endDate.DayOfWeek).Date;
			
			weekendDays = ((endMonday.Subtract(startMonday).TotalDays) / 7) * 2;
			
			// compute fractionary part of weekend days
			double diffStart = startDate.Subtract(startMonday).TotalDays - 5;
			double diffEnd = endDate.Subtract(endMonday).TotalDays - 5;
			
			// compensate weekenddays
			if(diffStart>0) weekendDays -= diffStart;
			if(diffEnd>0) weekendDays += diffEnd;
								
			return days - weekendDays;
		}
