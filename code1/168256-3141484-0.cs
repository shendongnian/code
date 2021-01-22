    /// <summary>
    /// Converts a string to sentence case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>A string</returns>
    public static string SentenceCase(string input)
    {
        if (input.Length < 1)
            return input;
    
        string sentence = input.ToLower();
        return sentence[0].ToString().ToUpper() +
           sentence.Substring(1);
    }
