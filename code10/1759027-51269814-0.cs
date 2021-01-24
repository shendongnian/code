    using System;
    using System.Net;
    					
    public class Program
    {
    	public static void Main()
    	{
            string goodIp = "127.0.0.1";
    		string badIp = "127.0.O.1";
    		
    		IPAddress ip;
    		if (IPAddress.TryParse(goodIp, out ip))
    		{
    			Console.WriteLine("Start your server");
    		}
    		
    		if (!IPAddress.TryParse(badIp, out ip))
    		{ 
    			Console.WriteLine("Bad IP");
    		}
    	}
    }
