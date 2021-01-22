    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    namespace ExecutionForwarder
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Stopwatch stopwatch = Stopwatch.StartNew();
    
    			Console.WriteLine($"Executing from folder: {Environment.CurrentDirectory} at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    
    			if (args.Length == 1 && args[0].ToLower().StartsWith("-delay:"))
    			{
    				int millisec;
    				if (Int32.TryParse(args[0].Substring(args[0].IndexOf(":") + 1), out millisec))
    				{
    					Console.WriteLine($"Sleeping for {millisec} milliseconds and will exit.");
    					Thread.Sleep(millisec);
    				}
    				else
    				{
    					Console.Error.WriteLine("Error while trying to read the delay.");
    					Environment.ExitCode = -99;
    				}
    			}
    			else
    			{
    				if (args.Length == 0)
    				{
    					Console.Error.WriteLine($"Can't forward execution. There is no argument (executable) provided.");
    					Environment.ExitCode = -99;
    				}
    				else
    				{
    					var result = ProcessWithOutputCapture.Execute(args[0], string.Join(" ", args.Skip(1)));
    					Console.Write(result.Output);
    					Console.Error.Write(result.Error);
    
    					Environment.ExitCode = result.ExitCode;
    				}
    			}
    
    			Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds} millisecs");
    		}
    	}
    }
