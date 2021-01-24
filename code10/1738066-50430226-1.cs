    class Program
    {
        static void Main(string[] args)
        {
            string strRegex = 
    @"^(?<grp>(?<machinenr>[^\|]{6})\|
    (?<controldone>[^\|]*)\|
    (?<nrofitems>[^\|]*)\|
    (?<items>(?:[^\|]{0,5}\|){1,}))*$";
            Regex myRegex = new Regex(strRegex, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            string strTargetString = @"446408|0|1|111|446408|0|3|99884|111|73732|446408|0|0||";
            MatchCollection matches = myRegex.Matches(strTargetString);
            foreach (Match m in matches)
            {
                for (int idx = 0; idx < m.Groups["grp"].Captures.Count; idx++)
                {
                    Console.WriteLine("Group:");
                    Console.WriteLine($"\tmachinenr={m.Group["machinenr"].Captures[idx]}");
                    Console.WriteLine($"\tcontroldone={m.Groups["controldone"].Captures[idx]}");
                    Console.WriteLine($"\tnrofitems={m.Groups["nrofitems"].Captures[idx]}");
                    Console.WriteLine($"\titems={m.Groups["items"].Captures[idx]}");
                }
            }
        }
    }
