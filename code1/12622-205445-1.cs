     static void Main(string[] args)
     {
         string input = "EQUIP:12312dd23";
         string output = Regex.Replace(input, @"(EQUIP:)(\S+)", 
             new MatchEvaluator(genURL), RegexOptions.IgnoreCase);
         Console.WriteLine(output);
         Console.ReadKey();
     }
     static string genURL(Match m)
     {
         return string.Format(@"<a title=""View item {0}"" 
                href=""/EqDisp.asp?eq={2}"">{1}{0}</a>",
                m.Groups[2].Value,m.Groups[1].Value,m.Groups[2].Value.ToUpper());
     }
