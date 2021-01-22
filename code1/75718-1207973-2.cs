    using System;
    using System.Runtime.InteropServices;
    
    public class Woot
    {
      [DllImport("perlembed.so", SetLastError = true)]
      public static extern void Initialize(string processName, string perlFile);
      
      [DllImport("perlembed.so", SetLastError = true)]
      public static extern void Call(string subName);
      
      [DllImport("perlembed.so", SetLastError = true)]
      public static extern void Dispose();
    
    	static void Main()
    	{
    		Console.WriteLine("Starting up C#...");
    		
    		try
    		{
    			Initialize("perlembed.exe", "showtime.pl");
    			
    			Call("showtime");
    		}
    		catch(Exception exc)
    		{
    			Console.WriteLine(exc.ToString());
    		}
    		finally
    		{
    			Dispose();
    		}
    		
    		Console.WriteLine("DONE!...");
    	}
    }
