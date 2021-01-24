    private List<string> ParseObject(StringBuilder body, string parser)
    {
        List<string> pages = new List<string>();
        string data = body.ToString();
        int splitPos = 0;
        int startPos = 0;
        while (true)
        {
            int totalPos = data.IndexOf(parser, splitPos);
            if (totalPos != -1)
            {
                splitPos = data.IndexOf(Environment.NewLine, totalPos);
                pages.Add(data.Substring(startPos, splitPos - startPos).Trim());
                startPos = splitPos;
            }
            else
                break;
        }
        return pages;
    }
