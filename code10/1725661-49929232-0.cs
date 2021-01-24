    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main()
    	{
    		var cts = new CancellationTokenSource();
    		var token = cts.Token;
            // The first task
    		var task1 = Task.Run(() => {
    			Console.WriteLine("Task1");
    		}, token);
    		
            // The second task
    		var task2 = Task.Run(() =>
    		{
    			while (true)
    			{
    				Task.Delay(1000);
    				Console.WriteLine("Task2");
    			}
    		}, token);
            // When one of them completes, cancel the other.    		
    		Task.WhenAny(task1, task2).GetAwaiter().GetResult();
    		cts.Cancel();
    		Task.Delay(3000);
    	}
    }
