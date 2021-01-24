    static string TrimEndSpaces(string input)
    {
        // If the input is null, there's nothing to do - just return null
        if (input == null) return input;
        // Our array of valid ending punctuation
        char[] validEndingPunctuation = { '.', ':', ',', ';', '!', '?' };
        // This will contain our final result
        var result = new StringBuilder();
        // Walk backwards through the input string
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (validEndingPunctuation.Contains(input[i]))
            {
                // Valid character, so add it and keep going backwards
                result.Insert(0, input[i]);
                continue;
            }
            if (input[i] == ' ')
            {
                // Space character at end - skip it
                continue;
            }
            // Regular character found - we're done. Add the rest of the string
            result.Insert(0, input.Substring(0, i + 1));
            break;
        }
        return result.ToString();
    }
