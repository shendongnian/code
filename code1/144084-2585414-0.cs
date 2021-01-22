    public static string GetIndefinateArticle(string noun)
    {
        if (Regex.Matches(noun, "^([aeio]|un|ul)", RegexOptions.IgnoreCase))
            return "an " + noun;
        else
            return "a " + noun;
    }
