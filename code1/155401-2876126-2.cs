    using System;
    using System.Management;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var searcher = new ManagementObjectSearcher
                   ("SELECT * FROM WIN32_SerialPort"))
                {
                    foreach (var port in searcher.Get())
                    {
                        // this prints out port descriptive caption
                        Console.WriteLine(port["Caption"].ToString());
                        Console.WriteLine();
                    }
                }
                
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
