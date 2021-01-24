    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		string Content = "Server:  volvo.toyota.opel.tata \rAddress:  5.6.7.8 \rName:    DynamicLengthString.toyota.opel.tata  \rAddress:  1.2.3.4";
    		string Pattern = "(?<=DynamicLengthString)(?s)(.*$)";
    		//string Pattern = @"/^Dy*$/";
    		MatchCollection matchList = Regex.Matches(Content, Pattern);
    		 Console.WriteLine("Running");
    		
    		foreach(Match match in matchList)
    		{
    			 Console.WriteLine(match.Value);
    		}
    	}
    }
