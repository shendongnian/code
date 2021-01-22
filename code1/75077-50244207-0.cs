    using System;
    using System.Runtime.InteropServices;
    
    namespace CheckIfConsoleWillBeDestroyedAtTheEnd
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			// ...
    
    			if (ConsoleWillBeDestroyedAtTheEnd())
    			{
    				Console.WriteLine("Press any key to continue . . .");
    				Console.ReadLine();
    			}
    		}
    
    		private static bool ConsoleWillBeDestroyedAtTheEnd()
    		{
    			var processList = new uint[1];
    			var processCount = GetConsoleProcessList(processList, 1);
    			
    			return processCount == 1;
    		}
    
    		[DllImport("kernel32.dll", SetLastError = true)]
    		static extern uint GetConsoleProcessList(uint[] processList, uint processCount);
    	}
    }
