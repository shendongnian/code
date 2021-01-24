    public string Strip(string text, char c)
    {
        Regex regex = new Regex(c.ToString() + @"[^\s]");
        return regex.Replace(text, "");
    }
