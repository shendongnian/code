    using System;
    using System.Diagnostics;
    
    namespace Win64ProcesPath {
        class Program {
            static void Main (string[] args) {
                Process myProcess = new Process ();
    
                try {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "calc.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start ();
                    System.Threading.Thread.Sleep (1000);
                    Console.WriteLine ("{0}", myProcess.MainModule.FileName);
    
                    Process p = Process.GetProcessById (myProcess.Id);
                    Console.WriteLine ("{0}", p.MainModule.FileName);
    
                    //Process p32 = Process.GetProcessById (8048);
                    //Console.WriteLine ("{0}", p32.MainModule.FileName);
                }
                catch (Exception e) {
                    Console.WriteLine (e.Message);
                }
            }
        }
    }
