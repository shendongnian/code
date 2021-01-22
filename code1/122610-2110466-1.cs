        static void Main(string[] args)
        {
            { //LINQ version
                bool hasFoo = "file.txt".AsLines()
                                        .Any(l => l.Contains("foo"));
            }
            { // No LINQ or Extension Methods needed
                bool hasFoo = false;
                foreach (var line in Tools.AsLines("file.txt"))
                    if (line.Contains("foo"))
                    {
                        hasFoo = true;
                        break;
                    }
            }
        }
    }
    public static class Tools
    {
        public static IEnumerable<string> AsLines(this string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    while (line.EndsWith("-") && !reader.EndOfStream)
                        line = line.Substring(0, line.Length - 1)
                                    + reader.ReadLine();
                    yield return line;
                }
        }
    }
