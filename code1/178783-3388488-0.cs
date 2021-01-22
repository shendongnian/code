    void Main()
    {
    	var dates = new[] {new DateTime(2000,1,1), new DateTime(2000,1,5)};
    	DateHelper.Range(new DateTime(2000,1,1), new DateTime(2000,1,5)).Except(dates).Dump();
    }
    
    // Define other methods and classes here
    public static class DateHelper {
    	public static IEnumerable<DateTime> Range(DateTime start, DateTime end) {
    		var days = end.Subtract(start).Days;
    		var next = start;
    		for(var i = 0; i<days; i++) {
    			next = next.AddDays(1);
    			yield return next;
    		}
    	}
    }
