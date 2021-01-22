    public class GetFiles
    {
        public static void Main(string[] args)
        {
            FileInfo[] files = 
                new DirectoryInfo(@"D:\downloads\_Installs").GetFiles();
            ArrayList exefiles = new ArrayList();
            foreach (FileInfo f in files)
            {
                if (f.Extension == ".exe") // or whatever matching you want to do.
                {
                    exefiles.Add(f);
                }
            }
            foreach (FileInfo f in exefiles)
            {
                Console.WriteLine(f.FullName);
            }
            Console.ReadKey();
        }
    }
