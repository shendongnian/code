    static IEnumerable<string> ReadLines(string path) {
        using (var file = File.OpenText(path)) {
            string line;
            while ((line = file.ReadLine()) != null) {
                yield return line;
            }
        }
    }
        var data = (from line in ReadLines(path)
                    let parts = line.Split(',')
                    select new {
                        Key = parts[0].Trim('"', ' '),
                        Value = int.Parse(parts[1].Trim())
                    }).ToDictionary(x => x.Key, x => x.Value);
