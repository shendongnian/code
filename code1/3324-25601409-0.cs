        private List<string> SplitScriptGo(string script)
        {
            var result = new List<string>();
            int pos1 = 0;
            int pos2 = 0;
            bool whiteSpace = true;
            bool emptyLine = true;
            bool inStr = false;
            bool inComment1 = false;
            bool inComment2 = false;
            while (true)
            {
                while (pos2 < script.Length && Char.IsWhiteSpace(script[pos2]))
                {
                    if (script[pos2] == '\r' || script[pos2] == '\n')
                    {
                        emptyLine = true;
                        inComment1 = false;
                    }
                    pos2++;
                }
                if (pos2 == script.Length)
                    break;
                bool min2 = (pos2 + 1) < script.Length;
                bool min3 = (pos2 + 2) < script.Length;
                if (!inStr && !inComment2 && min2 && script.Substring(pos2, 2) == "--")
                    inComment1 = true;
                if (!inStr && !inComment1 && min2 && script.Substring(pos2, 2) == "/*")
                    inComment2 = true;
                if (!inComment1 && !inComment2 && script[pos2] == '\'')
                    inStr = !inStr;
                if (!inStr && !inComment1 && !inComment2 && emptyLine
                    && (min2 && script.Substring(pos2, 2).ToLower() == "go")
                    && (!min3 || char.IsWhiteSpace(script[pos2 + 2]) || script.Substring(pos2 + 2, 2) == "--" || script.Substring(pos2 + 2, 2) == "/*"))
                {
                    if (!whiteSpace)
                        result.Add(script.Substring(pos1, pos2 - pos1));
                    whiteSpace = true;
                    emptyLine = false;
                    pos2 += 2;
                    pos1 = pos2;
                }
                else
                {
                    pos2++;
                    whiteSpace = false;
                    if (!inComment2)
                        emptyLine = false;
                }
                if (!inStr && inComment2 && pos2 > 1 && script.Substring(pos2 - 2, 2) == "*/")
                    inComment2 = false;
            }
            if (!whiteSpace)
                result.Add(script.Substring(pos1));
            return result;
        }
