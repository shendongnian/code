    /// <summary>
    /// Filters illegal characters out of the given text, and converts
    /// any characters in the 0x00-0x1F range to control code symbols.
    /// Used for filtering file, keyboard and clipboard input.
    /// </summary>
    /// <param name="text">Input text</param>
    /// <returns>Text containing only normal ASCII characters, special > 127 characters of the chosen encoding, or control code characters for the 0x00-0x1F range</returns>
    private String FilterText(String text)
    {
        // Filter out null characters; they're completely illegal.
        Char[] inputch = text.Replace(Environment.NewLine, "\r").Where(x => x != '\0').ToArray();
        // Make string for easy IndexOf lookup
        String validCharsLowRange = new String(_validCharactersLowRange);
        for (Int32 i = 0; i < inputch.Length; i++)
        {
            Char inputChar = inputch[i];
            // Ignore line breaks
            if (inputChar == '\r')
                continue;
            // Check for low range characters to replace
            Int32 index = validCharsLowRange.IndexOf(inputChar);
            if (index == -1)
                continue;
            inputch[i] = ASCII_CONTROL[index];
        }
        // Filter out illegal characters
        return new String(inputch.Where((x => x == '\r' || this._validCharacters.Contains(x))).ToArray()).Replace("\r", Environment.NewLine);
    }
