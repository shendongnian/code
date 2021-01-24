    private static char[] replacements = new[]
    {
        'ø',
        'Ù'
    };
    private static string HandleMatch(Match m)
    {
        // The pattern for the Regex will only match a single character, so get that character
        char c = m.Value[0];
        // Check if this is one of the characters we want to replace
        if (!replacements.Contains(c))
        {
            return m.Value;
        }
        // Convert the character to the 4 hex digit code
        string code = ((int) c).ToString("X4");
        // Format and return the code
        return "&#x" + code;
    }
