            string tag = "!!Part|123456,ABCDEF,ABC132!!";
            string partRegularExpression = @"(?:^!!PART\|){0,1}(?<value>.*?)(?:,|!!$)";
            ArrayList results = new ArrayList();
            Regex extractNumber = new Regex(partRegularExpression, RegexOptions.IgnoreCase);
            MatchCollection matches = extractNumber.Matches(tag);
            foreach (Match match in matches)
            {
                results.Add(match.Groups["value"].Value);
            }            
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
