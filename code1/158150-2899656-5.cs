    string TruncateText(string input, int characterLimit)
    {
        if (input.Length > characterLimit)
        {
            // find last whitespace immediately before limit
            int whitespacePosition = input.Substring(0, characterLimit).LastIndexOf(" ");
            // or find first whitespace after limit (what is spec?)
            // int whitespacePosition = input.IndexOf(" ", characterLimit); 
            if (whitespacePosition > -1)
                return input.Substring(0, whitespacePosition);
        }
        return input;
    }
