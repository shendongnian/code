    static IEnumerable<string> EnumerateLines(string path) {
        using(var reader = File.OpenText(path)) {
            string line;
            while(null != (line = reader.ReadLine())
                yield return line;
        }
    }
