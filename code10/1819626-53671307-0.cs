    using System;
    using System.IO;
    
    namespace sandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fileName = @"/Users/cetinBasoz/Desktop/customer.csv";
                if (File.Exists(fileName))
                {
                    var content = File.ReadLines(fileName);
                    foreach (var line in content)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine($"Dumped contents of {fileName}");
                }
            }
        }
    }
