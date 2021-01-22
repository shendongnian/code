    namespace EraseJunkFiles
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo yourRootDir = new DirectoryInfo(@"C:\yourdirectory\");
                foreach (FileInfo file in yourRootDir.GetFiles())
                    if (file.LastWriteTime < DateTime.Now.AddDays(-90))
                        file.Delete();
            }
        }
    }
