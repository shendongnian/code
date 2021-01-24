    public static string GetNumberAfterKeyword(string input, string keyword)
    {
        // Decide what you want to do if no keyword is found
        if (string.IsNullOrEmpty(input) || !input.Contains(keyword)) return string.Empty;
        return string.Concat(input
            .Substring(input.IndexOf(keyword) + keyword.Length)
            .TakeWhile(char.IsDigit));
    }
