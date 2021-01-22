    Regex regex = new Regex(@"[a-zA-Z]*", RegexOptions.Compiled);
    private string CamelCase(string str)
    {
        return regex.Matches(str).OfType<Match>().Aggregate("", (s, match) => s + CamelWord(match.Value));
    }
    private string CamelWord(string word)
    {
        if (string.IsNullOrEmpty(word))
            return "";
        return char.ToUpper(word[0]) + word.Substring(1).ToLower();
    }
