    List<string> splitCombine(string source, string delimiter, int startIndex)
    {
        List<string> result = new List<string>();
        var indx = source.IndexOf(delimiter, startIndex);
        if (indx >= 0)
        {
            if (indx > 0)
            {
                result.Add(source.Substring(0, indx));
            }
            result.AddRange(splitCombine(source, delimiter, ++indx));
        }
        else
        {
            result.Add(source);
        }
        return result;
    }
