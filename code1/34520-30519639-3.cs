    public static int CountOccurrences(string original, string substring)
    {
        if (string.IsNullOrEmpty(substring))
            return 0;
        if (substring.Length == 1)
            return CountOccurrences(original, substring[0]);
        if (string.IsNullOrEmpty(original) ||
            substring.Length > original.Length)
            return 0;
        int substringCount = 0;
        for (int charIndex = 0; charIndex < original.Length; charIndex++)
        {
            for (int subCharIndex = 0, secondaryCharIndex = charIndex; subCharIndex < substring.Length && secondaryCharIndex < original.Length; subCharIndex++, secondaryCharIndex++)
            {
                if (substring[subCharIndex] != original[secondaryCharIndex])
                    goto continueOuter;
            }
            charIndex += substring.Length - 1;
            substringCount++;
            if (charIndex + substring.Length >= original.Length)
                break;
        continueOuter:
            ;
        }
        return substringCount;
    }
    public static int CountOccurrences(string original, char @char)
    {
        if (string.IsNullOrEmpty(original))
            return 0;
        int substringCount = 0;
        for (int charIndex = 0; charIndex < original.Length; charIndex++)
            if (@char == original[charIndex])
                substringCount++;
        return substringCount;
    }
