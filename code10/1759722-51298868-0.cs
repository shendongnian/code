    using System;
    using System.Threading.Tasks;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string r;
    		OutputThreadInfo("Main");
    		r = MyMethod().Result;
    		r = Task.Run( () => MyMethod() ).Result;
    	}
    	
    	public static async Task<string> MyMethod()
    	{
    		OutputThreadInfo("MyMethod");
    		await Task.Delay(50);
    		return "finished";
    	}
    	
    	private static void OutputThreadInfo(string context)
    	{
    		Console.WriteLine("{0} {1}",context,System.Threading.Thread.CurrentThread.ManagedThreadId);
    	}
    }
