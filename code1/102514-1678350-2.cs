    int MAX_LEN = 60;
    StringBuilder sb = new StringBuilder();
    int bmark = 0; //bookmark position
    
    Regex.Replace(strInput, @".*?\b\w+\b.*?", 
        delegate(Match m) {
            if (m.Index - bmark + m.Length + m.NextMatch().Length > MAX_LEN 
                    || m.Index == bmark && m.Length >= MAX_LEN) {
                sb.Append(strInput.Substring(bmark, m.Index - bmark + m.Length).Trim() + Environment.NewLine);
                bmark = m.Index + m.Length;
            } return null;
        }, RegexOptions.Singleline);
    
    if (bmark != strInput.Length) // last portion
        sb.Append(strInput.Substring(bmark));
    
    string strModified = sb.ToString(); // get the real string from builder
