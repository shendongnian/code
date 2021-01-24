    public static double CodeToCommentRatio(
        string text, 
        out int codeChars, 
        out int commentChars, 
        out int blankChars)
    {
        // First, filter out excess whitespace, reporting the number of characters removed this way
        Regex lineStartRegex = new Regex(@"(^|\n)[ \t]+");
        Regex blanksRegex = new Regex(@"[ \t]+");
        string minWhitespaceText = blanksRegex.Replace(lineStartRegex.Replace(text, "\n"), " ");
        blankChars = text.Length - minWhitespaceText.Length;
        // Then, match all comments and report the number of characters in comments
        Regex commentsRegex = new Regex(@"(/\*(?>[^*]|(\*+[^*/]))*\*+/)|(//.*)");
        MatchCollection comments = commentsRegex.Matches(minWhitespaceText);
        commentChars = 0;
        foreach (Match comment in comments)
        {
            commentChars += comment.Length;
        }
        codeChars = minWhitespaceText.Length - commentChars;
        // Finally, return the ratio
        return (double)codeChars / commentChars;
    }
