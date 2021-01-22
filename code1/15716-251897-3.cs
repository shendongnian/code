    Dictinary<string,string> match_filename(string rule, string filename) {
        Regex tag_re = new Regex(@'%(\w+)%');
        string pattern = tag_re.Replace(Regex.escape(rule), @'(?<$1>.*?)');
        Regex filename_re = new Regex(pattern);
        Match match = filename_re.Match(filename);
        Dictionary<string,string> tokens =
                new Dictionary<string,string>();
        for (int counter = 1; counter < match.Groups.Count; counter++)
        {
            string group_name = filename_re.GroupNameFromNumber(counter);
            tokens.Add(group_name, m.Groups[counter].Value);
        }
        return tokens;
    }
