    bool IsTitleCase(string text)
    {
        if (string.IsNullOrEmpty(text))
            return false;
        return text == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
    }
