    private void SplitCsv(string line, char separator, List<string> result)
    {
        if (line == "")
        {
            result.Add("");
            return;
        }
        if (line[0] == separator)
        {
            result.Add("");
            if (line == separator.ToString())
            {
                result.Add("");
            }
            else
            {
                SplitCsv(line.Substring(1), separator, result);
            }
        }
        else if (line[0] == '"')
        {
            if (line.IndexOf("\"" + separator) == -1)
            {
                result.Add(line.Substring(1, line.Length - 2));
            }
            else if (line.Substring(0, 3) == "\"\"" + separator)
            {
                result.Add("");
                SplitCsv(line.Substring(3), separator, result);
            }
            else
            {
                // we'll need to ignore escaped quotes
                int endPos = 0;
                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i] == '"')
                    {
                        if (line[i + 1] == separator && line[i - 1] != '"')
                        {
                            endPos = i;
                            break;
                        }
                    }
                }
                result.Add(line.Substring(1, endPos - 1));
                SplitCsv(line.Substring(endPos + 2), separator, result);
            }
        }
        else
        {
            if (line.IndexOf(separator) == -1)
            {
                result.Add(line);
            }
            else
            {
                result.Add(line.Substring(0, line.IndexOf(separator)));
                SplitCsv(line.Substring(line.IndexOf(separator) + 1), separator, result);
            }
        }
    }
