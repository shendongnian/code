    public class MyParser {
        public IEnumerable<T> Parse<T>(string path) {
            var lines = File.ReadLines(path);
            foreach (var line in lines) {
                var record = JsonConvert.DeserializeObject<T>(line);
                yield return record;
            }
        }
    }
    
