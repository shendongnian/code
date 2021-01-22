        static void Main(string[] args)
        {
                Hashtable hashtable = new Hashtable();
                string[] fileLines = File.ReadAllLines(@"PATH\FILE.TXT");
    
                foreach (string line in fileLines)
                {
                var match =  Regex.Match(line, @"^(\d+)\s+([^/]+)\s+/\s+(.+)$");
                hashtable.Add(match.Groups[0].ToString(), new string[] { match.Groups[1].ToString(), match.Groups[2].ToString() });
                }
            }
