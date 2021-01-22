    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"d:\test.htm");
            Regex regex = new Regex("href\\s*=\\s*\"([^\"]*)\"", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);
            foreach(Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
