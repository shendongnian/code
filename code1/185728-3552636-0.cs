    public static class StringExtensions
    {
        public static IEnumerable<string> ReadLines(this string data)
        {
            using (var sr = new StringReader(data))
            {
                string line;
        
                while ((line = sr.ReadLine()) != null)
                    yield return line;
            }
        }
        
        public static string[] ReadAllLines(this string data)
        {
            var res = new List<string>();
        
            using (var sr = new StringReader(data))
            {
                string line;
        
                while ((line = sr.ReadLine()) != null)
                    res.Add(line);
            }
        
            return res.ToArray();
        }
    }
