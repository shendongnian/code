    class Program
    {
        static void Main(string[] args)
        {
            bool hasFoo = "file.txt".AsLines().Any(l => l.Contains("foo"));
        }
    }
    public static class Tools
    {
        public static IEnumerable<string> AsLines(this string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
