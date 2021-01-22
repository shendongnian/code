    private static int CountOccurrences(string original, string substring)
    {
        if (string.IsNullOrEmpty(original) || 
            string.IsNullOrEmpty(substring) ||
            substring.Length > original.Length)
            return 0;
        int substringCount = 0;
        for (int charIndex = 0; charIndex < original.Length; charIndex++)
        {
            for (int subCharIndex = 0, secondaryCharIndex = charIndex; subCharIndex < substring.Length && secondaryCharIndex < original.Length; subCharIndex++, secondaryCharIndex++)
                if (substring[subCharIndex] != original[secondaryCharIndex])
                    goto continueOuter;
            substringCount++;
            if (charIndex + substring.Length >= original.Length)
                break;
        continueOuter:
            ; //Avoid compiler error.  Too bad there's no break continue.
        }
        return substringCount;
    }
