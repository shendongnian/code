    public static string ReplaceConsecutiveCharacters(string input, char search,
        int minConsecutiveCount, string replace)
    {
        return input == null
            ? null
            : new Regex($"[{search}]{{{minConsecutiveCount},}}", RegexOptions.None)
                .Replace(input, replace);
    }
