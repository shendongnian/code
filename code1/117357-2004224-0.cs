        public IEnumerable<string> GetRandomLines(string path, int lines)
        {
            foreach (var line in File.ReadAllLines(path).OrderBy(s => Guid.NewGuid()).Take(lines))
            {
                yield return line;
            }
        }
        
