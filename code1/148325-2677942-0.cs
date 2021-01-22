    using System;
    using System.IO;
    
    class Test
    {
        static void Main(string[] args)
        {
            string file = @"\\ServerA\FolderA\FolderB\File.jpg";
            FileInfo fi = new FileInfo(file);
            Console.WriteLine(fi.Name);                  // Prints File.jpg
            Console.WriteLine(fi.Directory.Name);        // Prints FolderB
            Console.WriteLine(fi.Directory.Parent.Name); // Prints FolderA
        }
    }
