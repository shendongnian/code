    public class GetFiles
    {
        public static void Main(string[] args)
        {
            FileInfo[] files = new DirectoryInfo(@"D:\downloads\_Installs").GetFiles();
            var exefiles = from FileInfo f in files 
                           where f.Extension == ".exe" 
                           select f;
            foreach (FileInfo f in exefiles)
            {
                Console.WriteLine(f.FullName);
            }
            Console.ReadKey();
        }
    }
