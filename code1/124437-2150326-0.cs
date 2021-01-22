    public static class Extensions
    {
    	public static string ToCustomFormat(this DateTime date)
    	{
    		if (date == DateTime.Today)
    		{
    			return date.AddDays(-1).ToString("MM/dd/yyyy") + " 24:00";
    		}
    		return date.ToString("MM/dd/yyyy H:mm");
    	}
    }
