    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace KillSpawnedProcesses
    {
        class Program
        {
            static List<int> _processes = new List<int>();
    
            static void Main(string[] args)
            {
                Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
    
                StartProcesses();
                Console.Read(); //to hold up console
                Console.Read(); //to hold up console
            }
    
            static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
            {
                KillProcesses();
            }
    
            static void StartProcesses()
            {
                for(int i = 0; i < 2; i++)
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo();
                    p.StartInfo.FileName = "Notepad.exe";
                    p.Start();
                    _processes.Add(p.Id);
                }
            }
    
            static void KillProcesses()
            {
                foreach(var p in _processes)
                {
                    Process tempProcess = Process.GetProcessById(p);
                    tempProcess.Kill();
                }            
            }
        }
    }
