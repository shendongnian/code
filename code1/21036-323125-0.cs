        static IEnumerable<Foo> ReadFoos(string path) {
            return from line in ReadLines(path)
                   let parts = line.Split('|')
                   select new Foo { Name = parts[0],
                       Size = int.Parse(parts[1]) };
        }
        static IEnumerable<string> ReadLines(string path) {
            using (var reader = File.OpenText(path)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    yield return line;
                }
            }
        }
