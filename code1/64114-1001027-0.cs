    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var PrimaryString = "a - b - c";
    		var strPrimary  = PrimaryString.Split( new char[] { '-' }, 2 );
    		Console.WriteLine("First:{0}, Second:{1}",strPrimary[0],strPrimary[1]);
    		
    	}
    }
----------
    Output:
    First:a , Second: b - c
