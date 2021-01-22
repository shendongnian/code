    private void Parse(TextReader reader)
        {
            var row = new List<string>();
            var isStringBlock = false;
            var sb = new StringBuilder();
            long charIndex = 0;
            int currentLineCount = 0;
            while (reader.Peek() != -1)
            {
                charIndex++;
                char c = (char)reader.Read();
                if (c == '"')
                    isStringBlock = !isStringBlock;
                if (c == separator && !isStringBlock) //end of word
                {
                    row.Add(sb.ToString().Trim()); //add word
                    sb.Length = 0;
                }
                else if (c == '\n' && !isStringBlock) //end of line
                {
                    row.Add(sb.ToString().Trim()); //add last word in line
                    sb.Length = 0;
                    //DO SOMETHING WITH row HERE!
                    currentLineCount++;
                    
                    row = new List<string>();
                }
                else
                {
                    if (c != '"' && c != '\r') sb.Append(c == '\n' ? ' ' : c);
                }
            }
            row.Add(sb.ToString().Trim()); //add last word
            //DO SOMETHING WITH LAST row HERE!
        }
