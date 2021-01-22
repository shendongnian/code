    string TruncateText(string input, int characterLimit)
    {
        if (input.Length > characterLimit)
        {
            int whitespacePosition = input.IndexOf(" ", characterLimit);
            if (whitespacePosition > -1)
                return input.Substring(0, whitespacePosition);
        }
        return input;
    }
