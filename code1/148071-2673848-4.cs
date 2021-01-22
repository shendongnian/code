    private void Generate2()
    {
        Regex customCodeRegex = new Regex("{CustomCode}");
        Regex dateRegex = new Regex("{Date}");
        Regex doubleSharpRegex = new Regex("{#+}");
    
        string customString = "Foo-{##}-{Date}-{CustomCode}-{####}";
    
        string newString = customCodeRegex.Replace(customString, "{0}");
        newString = dateRegex.Replace(newString, "{1}");
        newString = doubleSharpRegex.Replace(newString,
        match =>
        {
            string zeroPadding = match.Value.Substring(1, match.Value.Length - 2);
            zeroPadding = zeroPadding.Replace('#', '0');
            return "{2:" + zeroPadding + "}";
        });
    
        string customCode = "C001";
        string date = DateTime.Today.ToString("yyyyMMdd");
        string[] generatedCodes = new string[3];
        for (int i = 0; i < generatedCodes.Length; i++)
        {
            generatedCodes[i] = string.Format(newString, customCode, date, i);
        }
    }
