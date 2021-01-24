    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
		public async Task Identify() {
		 
			var cts = new CancellationTokenSource();
    		var token = cts.Token;
    		var task1 = Task.Run(() => {
    			Console.WriteLine("Task1");
    		}, token);
    		
    		var task2 = Task.Run(() => {
    			while (true) {
    				Task.Delay(1000);
    				Console.WriteLine("Task2");
    			}
    		}, token);
            // When one of them completes, cancel the other.    	
	        // Try commenting out the cts.Cancel() to see what happens.
    		await Task.WhenAny(task1, task2);
    		cts.Cancel();
		}
		
    	public static void Main()
    	{
			var p = new Program();
			p.Identify().GetAwaiter().GetResult();
    		Task.Delay(3000);
    	}
    }
