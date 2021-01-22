    using System;
    using System.IO;
    static class FileNameInUse
    {
        static void Main(string[] args)
        {
            string path = args[0];
            using (var stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Write to file
            }
        }
    }
