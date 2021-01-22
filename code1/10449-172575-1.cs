    using System;
    using System.IO;
    static class Program
    {
        static void Main()
        {
            string path = ""; // TODO
            ApplyAllFiles(path, ProcessFile);
        }
        static void ProcessFile(string path) {/* ... */}
        static void ApplyAllFiles(string folder, Action<string> fileAction)
        {
            foreach (string file in Directory.GetFiles(folder))
            {
                fileAction(file);
            }
            foreach (string subDir in Directory.GetDirectories(folder))
            {
                try
                {
                    ApplyAllFiles(subDir, fileAction);
                }
                catch
                {
                    // swallow, log, whatever
                }
            }
        }
    }
