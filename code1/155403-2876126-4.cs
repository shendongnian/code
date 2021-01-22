    using System;
    using System.Management;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO.Ports;        
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var searcher = new ManagementObjectSearcher
                    ("SELECT * FROM WIN32_SerialPort"))
                {
                    string[] portnames = SerialPort.GetPortNames();
                    var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                    var tList = (from n in portnames
                                join p in ports on n equals p["DeviceID"].ToString()
                                select n + " - " + p["Caption"]).ToList();
                    
                    tList.ForEach(Console.WriteLine);
                }
                
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
