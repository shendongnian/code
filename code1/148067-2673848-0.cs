    private void Generate()
    {
        Regex doubleSharpRegEx = new Regex("{#+}");
        string customString = "Foo {####}";
        string[] generatedCodes = new string[3];
        for (int i = 0; i < generatedCodes.Length; i++)
        {
            string newString = doubleSharpRegEx.Replace(customString,
                                                        match =>
                                                        {
                                                            // Calculate zero padding for format
                                                            // remove brackets
                                                            string zeroPadding = match.Value.Substring(1, match.Value.Length - 2);
                                                            // replace # with zero
                                                            zeroPadding = zeroPadding.Replace('#', '0');
    
                                                            return string.Format("{0:" + zeroPadding + "}", i);
                                                        });
            generatedCodes[i] = newString;
        }
    }
