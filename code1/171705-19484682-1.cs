    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace BatchRenamer
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dirnames = Directory.GetDirectories(@"C:\the full directory path of files to rename goes here");
                int i = 0;
                try
                {
                    foreach (var dir in dirnames)
                    {
                        var fnames = Directory.GetFiles(dir, "*.pdf").Select(Path.GetFileName);
                        DirectoryInfo d = new DirectoryInfo(dir);
                        FileInfo[] finfo = d.GetFiles("*.pdf");
                        foreach (var f in fnames)
                        {
                            i++;
                            Console.WriteLine("The number of the file being renamed is: {0}", i);
                            if (!File.Exists(Path.Combine(dir, f.ToString().Replace("(", "").Replace(")", ""))))
                            {
                                File.Move(Path.Combine(dir, f), Path.Combine(dir, f.ToString().Replace("(", "").Replace(")", "")));
                            }
                            else
                            {
                                Console.WriteLine("The file you are attempting to rename already exists! The file path is {0}.", dir);
                                foreach (FileInfo fi in finfo)
                                {
                                    Console.WriteLine("The file modify date is: {0} ", File.GetLastWriteTime(dir));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Read();
            }
        }
    }
