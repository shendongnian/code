    static public string ReplaceNonLetterCharsWithSpace(this string original)
    {
        var result = new StringBuilder();
        foreach (var ch in original)
        {
            result.Append(char.IsLetter(ch) ? ch : ' ');
        }
        return result.ToString();
    }
