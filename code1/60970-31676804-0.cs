    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Win32;
    
    namespace stackoverflowtesting
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<int, String> mappings = new Dictionary<int, string>();
    
                mappings[378389] = "4.5";
                mappings[378675] = "4.5.1 on Windows 8.1";
                mappings[378758] = "4.5.1 on Windows 8, Windows 7 SP1, and Vista";
                mappings[379893] = "4.5.2";
                mappings[393295] = "4.6 on Windows 10";
                mappings[393297] = "4.6 on Windows not 10";
    
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (true)
                    {
                        Console.WriteLine("Version: " + mappings[releaseKey]);
                    }
                }
                int a = Console.Read();
            }
        }
    }
