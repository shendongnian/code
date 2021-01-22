    public string textToProper(string text)
    {
       string ProperText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
                
       return ProperText;
    }
