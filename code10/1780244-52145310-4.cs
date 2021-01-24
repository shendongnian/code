    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace PlayAreaCSCon
    {
    	class Program
    	{
    		[DllImport("kernel32.dll")]
    		static extern IntPtr GetConsoleWindow();
    		static void Main(string[] args)
    		{
    			if (args.Length == 0)
    			{
					Console.Out.WriteLine("Hello");
					if (GetConsoleWindow() == IntPtr.Zero)
					{
						Console.Out.WriteLine("No Console window");
					}
					else
					{
						Console.Error.WriteLine("We have a console window");
					}
    			}
    			else
    			{
    				Process p = Process.Start(new ProcessStartInfo
    				{
    					FileName = "PlayAreaCSCon.exe",
    					Arguments = "",
    					CreateNoWindow = true,
    					UseShellExecute = false,
    					RedirectStandardOutput = true,
    					RedirectStandardError = true,
    				});
    
    				TextWriter streamOut = Console.Out;
    				TextWriter streamErr = Console.Error;
    				p.OutputDataReceived += (sender, e) =>
    				{
    					streamOut.WriteLine("Output => " + e.Data);
    				};
    
    				p.ErrorDataReceived += (sender, e) =>
    				{
    					streamErr.WriteLine("Error => " + e.Data);
    				};
    
    				p.BeginOutputReadLine();
    				p.BeginErrorReadLine(); // !!!
    				p.WaitForExit();
    			}
    		}
    	}
    }
