    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    using System.Diagnostics;
    
    namespace Management
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ps = Process.GetProcesses();
    
                foreach (var p in ps)
                {
                    try
                    {
                        var desc = FileVersionInfo.GetVersionInfo(p.MainModule.FileName);
                        Console.WriteLine(desc.FileDescription);
                    }
                    catch
                    {
                        Console.WriteLine("Access Denied");
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
