    using System;
    					
    public class Program
    {
    	public static void Main()
    	{	
          	SayHello(DateTime.Now);
    		SayHello(DateTime.Now.AddHours(6));
    	}
    	
    	private static void SayHello(DateTime time)
    	{
            if (time.Hour >= 4 && time.Hour < 12)
            {
    			Console.WriteLine(String.Format("good morning sir. It's {0} o'clock right now.", time));
            }
            else
            {                 
                 Console.WriteLine(String.Format("good afternoon sir. It's {0} o'clock right now.", time));
            }		
    	}
    	
    }
