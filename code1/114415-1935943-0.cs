    static IEnumerable<string> ReadLines(string path) {
        using (var file = File.OpenText(path)) {
            string line;
            while ((line = file.ReadLine()) != null) {
                yield return line;
            }
        }
    }
