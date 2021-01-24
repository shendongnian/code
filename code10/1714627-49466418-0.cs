    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
   	    public static void Main()
    	{
		    Regex regex = new Regex(@"\d+.\d+.\d+");
            Match match = regex.Match("firefox-10.0.2.source.tar.bz2");
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
	    }
    }
