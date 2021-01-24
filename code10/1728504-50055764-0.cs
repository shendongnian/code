    using System;    
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string s = "AT (1,2) ADDROOM RM0001";
    		Regex r = new Regex(@"\((\d+)[^\d]+(\d+)\)");
    		MatchCollection mc = r.Matches(s);
    		Console.WriteLine("First number is " + mc[0].Groups[1].Value);
    		Console.WriteLine("Second number is " + mc[0].Groups[2].Value);
    	}
    }
