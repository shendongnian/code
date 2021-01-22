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
                        // this prints out formatted textual info about the port
                        // ... essentially a textual presentation of 
                        // all the props under the port.
                        Console.WriteLine(port.GetText(TextFormat.Mof));
                        // walk every property on this port & output it...
                        foreach (PropertyData prop in port.Properties)
                        {
                            Console.WriteLine(prop.Name + ": " + prop.Value);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
