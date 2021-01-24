    public class Program
    {
    	public static void Main()
    	{
    		var d1=DateTime.Parse("1/2/18");
    		var d2=DateTime.Parse("2/3/18");
    		Console.WriteLine(d2.Subtract(d1).TotalDays);
    	}
    }
