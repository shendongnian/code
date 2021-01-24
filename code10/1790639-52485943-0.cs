    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string myDate = "23 June 2018";
            var newDate = DateTime.ParseExact(myDate, "dd MMMM yyyy", CultureInfo.InvariantCulture);
    		
    		Console.WriteLine(newDate.ToString());
    	}
    }
