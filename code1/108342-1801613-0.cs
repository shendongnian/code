    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace DeleteWhenBelow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dir = @"C:\Users\FixLoc\Documents\";
                var count = findAndDelete(dir, false, 1);
                Console.WriteLine(count);
            }
            static long findAndDelete(string folder, bool recurse, long filesize)
            {
                long count = 0;
                if(recurse)
                {
                    foreach (var d in Directory.GetDirectories(folder))
                    {
                        count += findAndDelete(d, recurse, filesize);
                    }
                }
                foreach (var f in Directory.GetFiles(folder))
                {
                    var fi = new FileInfo(f);
                    if (fi.Length < filesize)
                    {
                        File.Delete(f);
                        count++;
                    }
                }
                return count;
            }
        }
    }
