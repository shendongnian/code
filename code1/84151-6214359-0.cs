    public static string CleanUrl(string value)
    {
        if (value.IsNullOrEmpty())
            return value;
        // replace hyphens to spaces, remove all leading and trailing whitespace
        value = value.Replace("-", " ").Trim().ToLower();
        // replace multiple whitespace to one hyphen
        value = Regex.Replace(value, @"[\s]+", "-");
        // replace umlauts and eszett with their equivalent
        value = value.Replace("ß", "ss");
        value = value.Replace("ä", "ae");
        value = value.Replace("ö", "oe");
        value = value.Replace("ü", "ue");
        // removes diacritic marks (often called accent marks) from characters
        value = RemoveDiacritics(value);
        // remove all left unwanted chars (white list)
        value = Regex.Replace(value, @"[^a-z0-9\s-]", String.Empty);
        return value;
    }
