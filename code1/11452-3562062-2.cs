    class GlobTestMain
    {
        static void Main(string[] args)
        {
            string[] exes = Directory.GetFiles(Environment.CurrentDirectory, "*.exe");
            foreach (string file in exes)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }
