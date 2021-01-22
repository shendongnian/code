        int MAX_LEN = 60;
        List<string> lines = new List<string>();
        int bmark = 0; //bookmark position
        Regex.Replace(strInput, @".*?\b\w+\b.*?", delegate(Match m) {
                if (m.Index - bmark + m.Length + m.NextMatch().Length > MAX_LEN 
                        || m.Index == bmark && m.Length >= MAX_LEN) {
                    lines.Add(strInput.Substring(bmark, m.Index - bmark + m.Length).Trim());
                    bmark = m.Index + m.Length;
                } return null;
            }, RegexOptions.Singleline);
        if (bmark != strInput.Length) // last portion
            lines.Add(strInput.Substring(bmark));
