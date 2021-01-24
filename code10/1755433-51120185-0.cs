    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{		
    		string data = "[[\"0.45842413\",\"10\"],[\"0.45850028\",\"11\"],[\"0.46092215\",\"10\"],[\"0.478999\",\"133.69218728\"]]";
    		data = Regex.Replace(data, "(\"\\d+[.]{0,1}\\d{0,}\"),(\"\\d+[.]{0,1}\\d{0,}\")", "\"Price\":$1,\"Amount\":$2");
    		Console.WriteLine(data);
    	}
    }
