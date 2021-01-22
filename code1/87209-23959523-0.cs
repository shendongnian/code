    using System;
    using System.IO;
    namespace FileOrDirectory
    {
         class Program
         {
              public static string FileOrDirectory(string path)
              {
                   if (File.Exists(path))
                        return "File";
                   if (Directory.Exists(path))
                        return "Directory";
                   return "Path Not Exists";
              }
              static void Main()
              {
                   Console.WriteLine("Enter The Path:");
                   string path = Console.ReadLine();
                   Console.WriteLine(FileOrDirectory(path));
              }
         }
    }
