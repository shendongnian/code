    public static void TestFirstDayOfWeekExtension() {
    		int days = 30;
    		DateTime date = DateTime.Now.AddDays(-days);
    		for(int i = 0; i < days; i++) {				
    			Console.WriteLine($"{date.ToShortDateString()} :(2) First Day of week: {date.StartOfWeek().ToShortDateString()}");
    			date = date.AddDays(1);
    		}			
    
    	}
