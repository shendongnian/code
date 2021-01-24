     using System;
     using System.Management;
     namespace ConsoleApp1
     {
     class Program
     {
        static void Main(string[] args)
        {
            ManagementObjectSearcher searcher = new 
     ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
            string gc = "";
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData prop in obj.Properties)
                {
                    if (prop.Name == "Description")
                    {
                        gc = prop.Value.ToString().ToUpper();
                        if (gc.Contains("INTEL") == true)
                        {
                          Console.WriteLine("Your Graphic Card is Intel");
                        }
                        else if (gc.Contains("AMD") == true)
                        {
                            Console.WriteLine("Your Graphic Card is AMD");
                        }
                        else if (gc.Contains("NVIDIA") == true)
                        {
                            Console.WriteLine("Your Graphic Card is NVIDIA");
                        }
                        else
                        {
                            Console.WriteLine("Your Graphic Card cannot recognized.");
                        }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
    }
