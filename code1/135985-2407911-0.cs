    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            DirectoryInfo info = new DirectoryInfo("c:\\users\\jon\\test\\");
            Console.WriteLine(info.Name); // Prints test
        }                                                
    }
