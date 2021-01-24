    public bool HighlightExactMatchOnly(string input, string textToHighlight, string expected)
    {
        // given
        var escapedHighlight = Regex.Escape(textToHighlight);
    
        // when
        var result = Regex.Replace(input, @"\b" + escapedHighlight + @"\b", "<strong>$0</strong>");
    
        return expected == result;
    }
