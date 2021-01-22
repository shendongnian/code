    static void Main(string[] args)
        {
            string str = "{[\"a\",\"English\"],[\"b\",\"US\"],[\"c\",\"Chinese\"]}";
            foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(str, @"((\[.*?\]))"))
            {
                Console.WriteLine(m.Captures[0]);
            }
        }
 
