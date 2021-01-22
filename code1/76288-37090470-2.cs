    public string textToProper(string text)
    {
        string ProperText = string.Empty;
        if (!string.IsNullOrEmpty(text))
        {
            ProperText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
        else
        {
            ProperText = string.Empty;
        }
        return ProperText;
    }
