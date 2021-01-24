    using System.Threading.Tasks;
    class programe
    {
     // db1, startDate, middleDate all should static variables
     private static R resdata;
     public  static async Task Main(string[] args)
     {
    	Parallel.ForEach(GetSlots(db1, startDate, middleDate), async x =>
            {
    		resdata.res += x;
    	}
     }
     private static string GetSlots(db1, startDate, middleDate)
     {
    	return GetAvailableCalendarDatesAndSlots(db1, startDate, middleDate);
     }	
    }
    public class R
    {
    public string res { get;set; }
    }
