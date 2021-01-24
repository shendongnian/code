        public static async Task<string> GetServerNameForUser(string value)
        {
            string[] data = await ReadAllLinesAsync("C:\\test\\TestFile.txt");
            foreach(string log in data)
            {
                string[] temp = log.Split(',');
                if(temp[0].Contains(value))
                {
                    return temp[1];
                }
            }
            return "Not Found";
        }
        public static Task<string[]> ReadAllLinesAsync(string path)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8);
        }
        public static async Task<string[]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            var lines = new List<string>();
            // Open the FileStream with the same FileMode, FileAccess
            // and FileShare as a call to File.OpenText would've done.
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize, DefaultOptions))
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }
