    using System;
    using System.Text.RegularExpressions;
    
    namespace regexmonthtest
    {
    	class MainClass
    	{
    		
    		    // in your class, define 2 string patterns
    	    static string pattern = @"(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)";
    
    		public static void Main (string[] args)
    		{
    			Console.WriteLine (HasDate("FUTIDX 26FEB2009 NIFTY 0"));
    			Console.WriteLine (HasDate("FUTSTK MINIFTY 30 Jul 2009"));
    			Console.WriteLine (HasDate("FUTIDX 26api1234 NIFTY 0"));
    		}
    		
    
    	    public static bool HasDate (string textIn)
    	    {
    			textIn = textIn.ToLower();
    			Console.Write(textIn + '\t');
    			
    	        return (Regex.Match(textIn, pattern).Success);
    	    }
    	}
    }
