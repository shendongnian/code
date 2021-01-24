        public static void Main()
        {
            var testString = "one<span class=\"a-class\">two</span>three<a href=\"#a-link\">four</a>five";
            var matches = new Regex(@"^(?<Text>.*?)<|span class=""(?<Class>.*?)"">(?<Text>.*?)<\/span|a href=""(?<Link>.*?)"">(?<Text>.*?)<\/a|>(?<Text>.*?)<|>(?<Text>.+?)$").Matches(testString);
            var parts = from m in matches.Cast<Match>()
                        select new StringPart
                        {
                            Text = m.Groups["Text"].Value,
                            Class = m.Groups["Class"].Value,
                            Link = m.Groups["Link"].Value
                        };
            // dump
            foreach (var p in parts)
                Console.WriteLine($"{p.Text} -> {p.Info}");
        }
