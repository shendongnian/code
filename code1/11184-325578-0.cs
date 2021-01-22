    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static List<RunningProcess> runningProcesses = new List<RunningProcess>();
    
    		static void Main(string[] args)
    		{
    			Console.WriteLine("Starting...");
    
    			for (int i = 0; i < 100; i++)
    			{
    				DoSomethingOrTimeOut(30);
    			}
    
    			bool isSomethingRunning = false;
    
    			do
    			{
    				foreach (RunningProcess proc in runningProcesses)
    				{
    					// If this process is running...
    					if (proc.ProcessThread.ThreadState == ThreadState.Running)
    					{
    						isSomethingRunning = true;
    
    						// see if it needs to timeout...
    						if (DateTime.Now.Subtract(proc.StartTime).TotalSeconds > proc.TimeOutInSeconds)
    						{
    							proc.ProcessThread.Abort();
    						}
    					}
    				}
    			}
    			while (isSomethingRunning);
    			Console.WriteLine("Done!");    
    			Console.ReadLine();
    		}
    
    		static void DoSomethingOrTimeOut(int timeout)
    		{
    			runningProcesses.Add(new RunningProcess
    			{
    				StartTime = DateTime.Now,
    				TimeOutInSeconds = timeout,
    				ProcessThread = new Thread(new ThreadStart(delegate
    				  {
    					  // do task here...
    				  })),
    			});
    
    			runningProcesses[runningProcesses.Count - 1].ProcessThread.Start();
    		}
    	}
    
    	class RunningProcess
    	{
    		public int TimeOutInSeconds { get; set; }
    
    		public DateTime StartTime { get; set; }
    
    		public Thread ProcessThread { get; set; }
    	}
    }
