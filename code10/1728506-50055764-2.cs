    using System;    
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string s = "AT (1,1) ADDROOM RM0001";
    		Regex r = new Regex(@"\((\d+)[^\d]+(\d+)\)");
    		MatchCollection mc = r.Matches(s);
    		var firstNumber = mc[0].Groups[1].Value;
    		var secondNumber = mc[0].Groups[2].Value;
    	}
    }
