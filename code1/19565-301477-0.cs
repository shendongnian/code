    namespace Formatting
    {
    
        public static class DateTimeExtender
        {
    	    public static string ToCustomShortDate(this DateTime date)
    	    {
                return date.ToString("dd MMM yyyy");
    	    }
        }
    
        public class ProductionDetails
        {
            public DateTime StartDate { get; set; }    
        }
    }
