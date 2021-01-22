    static IEnumerable<string> ReadLines(string path) {
        using (var file = File.OpenText(path)) {
            string line;
            while ((line = file.ReadLine()) != null) {
                yield return line;
            }
        }
    }
    var data = (from line in ReadLines(path)
                select line.Split(','))
               .ToDictionary(
                  arr => arr[0].Trim('"', ' '),
                  arr => int.Parse(arr[1].Trim()));
