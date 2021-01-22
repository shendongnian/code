            string text = "1 AND 2 AND 3 OR 4";
            string pattern = @"AND|OR";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            ArrayList results = new ArrayList();
            while (m.Success)
            {
                results.Add(m.Groups[0].Value);
                m = m.NextMatch();
            }
            string[] matchesStringArray = (string[])results.ToArray(typeof(string));
