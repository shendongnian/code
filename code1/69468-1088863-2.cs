    using System;
    using System.Text.RegularExpressions;
    using System.Management;
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "select * from Win32_MappedLogicalDisk");
                foreach (ManagementObject drive in searcher.Get()) {
                    Console.WriteLine(Regex.Match(
                        drive["ProviderName"].ToString(),
                        @"\\\\([^\\]+)").Groups[1]);
                    }
                }
            }
        }
    }
