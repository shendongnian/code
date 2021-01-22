        static string Join(this IEnumerable<string> data, string delimiter) {
            using (var iter = data.GetEnumerator()) {
                if (!iter.MoveNext()) return "";
                StringBuilder sb = new StringBuilder(iter.Current);
                while (iter.MoveNext()) {
                    sb.Append(delimiter).Append(iter.Current);
                }
                return sb.ToString();
            }
        }
        static void Main() {
            var qry = from line in ReadLines("data.tsv")
                      let cells = line.Split('\t').Where(s => s != "")
                      select cells.Join("\t");
            using (var writer = File.CreateText("new.tsv")) {
                foreach(string line in qry) {
                    writer.WriteLine(line);
                }
            }
        }
