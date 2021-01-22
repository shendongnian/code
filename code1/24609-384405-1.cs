        static IEnumerable<string> ReadLines(string path) {
            using (StreamReader reader = File.OpenText(path)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    yield return line;
                }
            }
        }
