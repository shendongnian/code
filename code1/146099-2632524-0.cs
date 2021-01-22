    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string path = @"C:\Users\Jim\AppData\Local\Temp\";
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo parent = dir.Parent;
            Console.WriteLine(parent.FullName);
        }    
    }
