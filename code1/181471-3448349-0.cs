        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\\x[0-9]{2}");
            string s = @"Hello\x26\x2347World";
            var matches = regex.Matches(s);
            foreach(Match match in matches)
            {
                s = s.Replace(match.Value, ((char)Convert.ToByte(match.Value.Replace(@"\x", ""), 16)).ToString());
            }
            Console.WriteLine(s);
            Console.Read();
        }
