    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Main Start");
    		
    		UIEventHandler(2000);
    		UIEventHandler(500);
    		UIEventHandler(1000);
    		
    		Console.WriteLine("Main Stop");
    		
    		Thread.Sleep(3000);	// wait for tasks to finish
    	}
    
    	private static async Task LoadSomeData(int delay)
    	{
    		await Task.Run(() =>
    		{
    			Console.WriteLine("Start (LoadSomeData) " + delay);
    			Thread.Sleep(delay);
    			Console.WriteLine("Stop (LoadSomeData) " + delay);
    		});
    	}
    
    	private static async Task UIEventHandler(int delay)
    	{
    		Console.WriteLine("Start (UIEventHandler) " + delay);
    		await LoadSomeData(delay);
    		Console.WriteLine("Stop (UIEventHandler) " + delay);
    	}
    }
