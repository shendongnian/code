    public static class Tools
    {
        public static IEnumerable<string> ReadAsLines(this string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    return reader.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lines = "myfile.txt".ReadAsLines()
                                    // you could even add a filter query/formatting
                                    .Skip(100).Take(10) //do paging here
                                    .ToArray();
        }
    }
