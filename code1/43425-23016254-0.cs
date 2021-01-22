    static void Main(string[] args)
            {
                var scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();
     
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                var results = searcher.Get();
                Console.WriteLine("Network printers list:");
                foreach (var printer in results)
                {
                    var portName = printer.Properties["PortName"].Value;
     
                    var searcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_TCPIPPrinterPort where Name LIKE '" + portName + "'");
                    var results2 = searcher2.Get();
                    foreach (var printer2 in results2)
                    {
                        Console.WriteLine("Name:" + printer.Properties["Name"].Value);
                        //Console.WriteLine("PortName:" + portName);
                        Console.WriteLine("PortNumber:" + printer2.Properties["PortNumber"].Value);
                        Console.WriteLine("HostAddress:" + printer2.Properties["HostAddress"].Value);
                    }
                    Console.WriteLine();
                }
     
                Console.ReadLine();
               }
