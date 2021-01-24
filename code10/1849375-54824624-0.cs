     var daysInMonth = DateTime.DaysInMonth(year, month);
		    List<DateTime> list = new List<DateTime>();
		
            for (int day = daysInMonth; day > 0; day--)
            {
				DateTime currentDateTime = new DateTime(year, month, day);
				if (currentDateTime.DayOfWeek == DayOfWeek.Saturday)
				{
					list.Add(currentDateTime);
				}
           }
