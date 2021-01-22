        static void Main(string[] args)
        {
            string pattern = "(\\s|^)(?:keywords|from|database|with|esc@ped|characters|@ss|gr@ss)(\\s|$)"
            var matches = Regex.Matches("@ss is gr@ss is esc@ped keywordsnospace keywords", pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
