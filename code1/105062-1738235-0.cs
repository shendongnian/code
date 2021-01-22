    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.getAllFiles(@"D:\Old_Desktop");
        }
    
        public void getAllFiles(string directoryPath)
        {
                DirectoryInfo dirInfo= new DirectoryInfo(directoryPath);
                FileInfo[] files= dirInfo.GetFiles();
                foreach(FileInfo f in files)
                {
                    Console.WriteLine(f.FullName);
                }
                Console.ReadLine();
        }
    
    }
