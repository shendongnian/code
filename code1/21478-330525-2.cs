    public string Concat(IEnumerable<string> stringList)
    {
        StringBuilder textBuilder = new StringBuilder();
        string separator = String.Empty;
        foreach(string item in stringList)
        {
            textBuilder.Append(separator);
            textBuilder.Append(item);
            separator = ", ";
        }
        return textBuilder.ToString();
    }
