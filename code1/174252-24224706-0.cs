    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Test
    {
    	public static class Program
    	{
    		private static void Main()
    		{
    			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    
    			RunTask();
    
    			Thread.Sleep(2000);
    
    			GC.Collect();
    			GC.WaitForPendingFinalizers();
    			GC.Collect();
    
    			Console.ReadLine();
    		}
    
    		static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    		{
    			Console.WriteLine("Caught!");
    		}
    
    		private static void RunTask()
    		{
    			Task<int> task = Task.Factory.StartNew(() =>
    			{
    				Thread.Sleep(1000); // emulate some calculation
    				Console.WriteLine("Before exception");
    				throw new Exception();
    				return 1;
    			});
    		}
    	}
    }
