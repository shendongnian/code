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
            else
            {
                result.Add(line.Substring(1, line.IndexOf("\"" + separator) - 1));
                SplitCsv(line.Substring(line.IndexOf("\"" + separator) + 2), separator, result);
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
