    public List<string> SplitCSV(string line)
    {
        if (string.IsNullOrEmpty(line))
            throw new ArgumentException();
        List<string> result = new List<string>();
        int index = 0;
        int start = 0;
        bool inQuote = false;
        StringBuilder val = new StringBuilder();
        // parse line
        foreach (char c in line)
        {
            switch (c)
            {
                case '"':
                    inQuote = !inQuote;
                    break;
                case ',':
                    if (!inQuote)
                    {
                        result.Add(line.Substring(start, index - start)
                            .Replace("\"",""));
                        start = index + 1;
                    }
                    break;
                }
                index++;
            }
            if (start < index)
            {
                result.Add(line.Substring(start, index - start).Replace("\"",""));
            }
            return result;
        }
    }
