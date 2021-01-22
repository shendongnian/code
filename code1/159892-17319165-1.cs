    static IEnumerable<string> ParseSqlBatch(Stream s)
    {
        if (s == null)
            throw new ArgumentNullException();
    
        StringBuilder sbSqlStatement = new StringBuilder();
        Stack<string> state = new Stack<string>();
        StreamReader sr = new StreamReader(s);
    
        //initially search for "GO" or open tag of strings ('), comments (--, /*) or identifiers ([)
        string pattern = @"(?>(?<=^\s*)go(?=\s*(--.*)?$)|''(?!')|(?<!')'|(?<!\[)\[|--(?=.*)?|/\*)";
        //if open tag found search for close tag, then continue search
        string patternCloseString = @"(?>''|'(?!'))";
        string patternCloseIdentifier = @"(?>\]\]|\](?!\]))";
        string patternComments = @"(?>\*/|/\*)";
    
        Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
    
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
    
            int ix = 0;
            bool bBreak = false;
            while (ix < line.Length && !bBreak)
            {
                Match m = rx.Match(line, ix);
    
                if (!m.Success)
                {
                    sbSqlStatement.Append(line.Substring(ix));
                    break;
                }
    
                int ix2 = m.Index;
                string word = m.Value;
    
                sbSqlStatement.Append(line.Substring(ix, ix2 - ix));
    
                if (state.Count == 0)
                {
                    if (string.Compare(word, "GO", true) == 0)
                    {
                        if (sbSqlStatement.Length > 0)
                        {
                            yield return sbSqlStatement.ToString();
                            sbSqlStatement = new StringBuilder();
                            break;
                        }
                    }
                    else
                    {
                        switch (word)
                        {
                            case "'":
                                rx = new Regex(patternCloseString);
                                break;
                            case "[":
                                rx = new Regex(patternCloseIdentifier);
                                break;
                            case "/*":
                                rx = new Regex(patternComments);
                                break;
                            case "--":
                                sbSqlStatement.Append(line.Substring(ix2));
                                bBreak = true;
                                continue;
                        }
    
                        if (word != "''")
                            state.Push(word);
                    }
                }
                else
                {
                    string st = state.Peek();
    
                    switch (st)
                    {
                        case "'":
                            if (st == word)
                                state.Pop();
                            break;
                        case "[":
                            if (word == "]")
                                state.Pop();
                            break;
                        case "/*":
                            if (word == "*/")
                                state.Pop();
                            else if (word == "/*")
                                state.Push(word);
                            break;
                    }
    
                    if (state.Count == 0)
                        rx = new Regex(pattern, RegexOptions.IgnoreCase);
                }
    
                ix = ix2 + word.Length;
                sbSqlStatement.Append(word);
            }
    
            sbSqlStatement.AppendLine();
        }
    
        if (sbSqlStatement.Length > 0)
            yield return sbSqlStatement.ToString();
    }
