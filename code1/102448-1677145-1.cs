        static void Main() {
            var qry = from line in ReadLines("data.tsv")
                      let cells = line.Split('\t')
                      let format = cells.Length == 7 ? "{0}\t{4}\t{5}\t{6}"
                         : "{0}\t{1}\t{2}\t{3}"
                      select string.Format(format, cells);
            using (var writer = File.CreateText("new.tsv")) {
                foreach(string line in qry) {
                    writer.WriteLine(line);
                }
            }
        }
        static IEnumerable<string> ReadLines(string path) {
            using (var reader = File.OpenText(path)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    yield return line;
                }
            }
        }
