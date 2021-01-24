    using System;
    using System.Diagnostics;
    using System.ServiceProcess;
    
    namespace WinTImeSync
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (MsInfoReport() == true)
                {
                    Console.WriteLine("Command ran successfully.");
                }
                else
                {
                    Console.WriteLine("Did not run.");
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
    
            public static bool MsInfoReport()
            {
                try
                {
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    Process processTime = new Process();
                    processTime.StartInfo.FileName = @"C:\Program Files\Common Files\microsoft shared\MSInfo\msinfo32.exe";
                    processTime.StartInfo.Arguments = "/report " + desktopPath + "\\mypc_info.nfo /categories +systemsummary";
                    processTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processTime.Start();
                    processTime.WaitForExit();
    
                    return true;
                }
                catch (Exception exception)
                {
                    Trace.TraceWarning("unable to run msinfo32", exception);
                    return false;
                }
            }
        }
    }
