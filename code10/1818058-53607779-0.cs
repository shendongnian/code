    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var text = @":art!art@irc.org private #timing :\u000314CODEERROR:\u0003 [\u000304X012\u0003] Server time is different than UTC";
    		var res = Regex.Replace(text, @"\\u0{3}3\d{0,2}", string.Empty);
    		System.Console.WriteLine(res);
    	}
    }
