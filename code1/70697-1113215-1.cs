    using System;
    using System.Diagnostics;
    
    namespace ProcessExitSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    
                    Process firstProc = new Process();
                    firstProc.StartInfo.FileName = "notepad.exe";
                    firstProc.EnableRaisingEvents = true;
                    
                    firstProc.Start();
    
                    firstProc.WaitForExit();
                    
                    //You may want to perform different actions depending on the exit code.
                    Console.WriteLine("First process exited: " + firstProc.ExitCode);
    
                    Process secondProc = new Process();
                    secondProc.StartInfo.FileName = "mspaint.exe";
                    secondProc.Start();                
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred!!!: " + ex.Message);
                    return;
                }
            }
        }
    }
 
