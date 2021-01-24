c#
    static class Program
    {
        static void Main(string[] args)
        {
            using (var archive = ZipFile.OpenRead(args[0]))
            {
                var entry = archive.Entries.Where(_ => _.FullName.Equals("xl/comments1.xml", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (entry != null)
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var data = new List<string>(Decompress(entry.Open()));
                    var graph = new Graph(data);
                    stopwatch.Watch();
                    Console.ReadLine();
                }
            }
        }
        public static IEnumerable<string> Decompress(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
  [1]: https://i.stack.imgur.com/YxTbb.png
