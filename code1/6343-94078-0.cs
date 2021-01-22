        private void RegexTest()
        {
            String input = "foo[]=1&foo[]=5&foo[]=2";
            String pattern = @"foo\[\]=(\d+)";
            Regex regex = new Regex(pattern);
            foreach (Match match in regex.Matches(input))
            {
                Console.Out.WriteLine(match.Groups[1]);
            }
        }
