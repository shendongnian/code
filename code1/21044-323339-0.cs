    public static string CamelCaseToSentence(this string value)
    {
        var sb = new StringBuilder();
        var firstWord = true;
        foreach (var match in Regex.Matches(value, "([A-Z][a-z]+)|[0-9]+"))
        {
            if (firstWord)
            {
                sb.Append(match.ToString());
                firstWord = false;
            }
            else
            {
                sb.Append(" ");
                sb.Append(match.ToString().ToLower());
            }
        }
        return sb.ToString();
    }
