    using System;
    using System.IO;
    namespace Quicky
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string PREFIX = "ERISRequest_";
                DirectoryInfo di = new DirectoryInfo(@"C:\");
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name.StartsWith(PREFIX))
                    {
                        Console.WriteLine(Path.GetFileNameWithoutExtension(fi.Name).Substring(PREFIX.Length));
                    }
                }
            }
        }
    }
