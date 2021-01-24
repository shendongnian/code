    List<string> pages = new List<string>();
    
                string pattern = @"^(.*?Other Total:.*?)$";
                MatchCollection matches = Regex.Matches(lines, pattern, RegexOptions.Singleline|RegexOptions.Multiline);
                foreach (Match match in matches)
                {
                    pages.Add(match.Groups[1].Value);
                }
