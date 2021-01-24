    using System;
					
    public class Program
    {
	  public static void Main()
	  {
		  var d1=new DateTime(2018, 1, 6, 0, 8, 0);
		  var d2=new DateTime(2018, 1, 5, 0, 9, 0);
		  var span = d2.Subtract(d1);
	  	  Console.WriteLine(span.TotalDays);
		  Console.WriteLine(span.Days);
	  }
    }
