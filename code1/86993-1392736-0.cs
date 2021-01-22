    class Program
    {
        static void Main(string[] args)
        {
            var fileName = Path.ChangeExtension(Path.GetTempFileName(), "exe");
            File.WriteAllBytes(fileName, Resources.QueryExpress);
            var queryAnalyzer = Process.Start(fileName);
            queryAnalyzer.WaitForExit();
        }
    }
