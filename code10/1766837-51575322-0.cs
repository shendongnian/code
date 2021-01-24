    using System;
    using System.IO;
    namespace Quicky
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\");
                foreach (FileInfo fi in di.GetFiles())
                {
                    string name = Path.GetFileNameWithoutExtension(fi.Name);
                    if (name.StartsWith("ERISRequest_"))
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
