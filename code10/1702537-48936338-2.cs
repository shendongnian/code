    private List<string> ParseObject(StringBuilder body, string parser)
    {
        List<string> pages = new List<string>();
        string data = body.ToString();
        int splitPos = 0;
        int startPos = 0;
        while (true)
        {
            // Search the position of the parser string starting from the
            // previous found pos
            int parserPos = data.IndexOf(parser, splitPos);
            if (parserPos != -1)
            {
                // Now we search the position of the newline after the 
                // found parser pos
                splitPos = data.IndexOf(Environment.NewLine, parserPos);
                // Take the substring starting from the previous position up to
                // the current newline position 
                pages.Add(data.Substring(startPos, splitPos - startPos).Trim());
                // reposition to the new starting position for IndexOf
                startPos = splitPos;
            }
            else
                break;
        }
        return pages;
    }
