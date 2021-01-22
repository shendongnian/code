    string TruncateText(string input, int characterLimit)
    {
        if (input.Length > characterLimit)
        {
            int whitespacePosition = input.IndexOf(" ", characterLimit);
            // alternate: 
            // int whitespacePosition = input.Substring(0, characterLimit).LastIndexOf(" ");
            if (whitespacePosition > -1)
                return input.Substring(0, whitespacePosition);
        }
        return input;
    }
