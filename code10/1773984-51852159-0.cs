    public static void Main()
    {
        var GetDate = new DateTime(2000, 01, 01, 00, 00, 00, 000);
    
        // Using The regular way 
        var resukt = GetDate.AddDays(1.125);
        // using my method 
        var result = GetDate.Add(1, 3, 00, 0, 0);
    
        Console.WriteLine(resukt.ToString("yyyy'/'MM'/'dd HH:mm:ss.fffff"));
        Console.WriteLine(result.ToString("yyyy'/'MM'/'dd HH:mm:ss.fffff"));
    
       // outputs 
       //2000/01/02 03:00:00.00000
       //2000/01/02 03:00:00.00000
    
    
        Console.ReadLine();
    }
    
    public static class DatimeExtensions
    {
    	public static DateTime Add(this DateTime date, int day, int hour, int minute, int second, int millisecond) =>
    		date.AddDays(day).AddHours(hour).AddMinutes(minute).AddSeconds(second).AddMilliseconds(millisecond);
    }
