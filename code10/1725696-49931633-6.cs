    public static bool TryGetNumberAfterKeyword(string input, string keyword, out int result)
    {
        bool foundResult = false;
        result = 0;
            
        if (!string.IsNullOrEmpty(input) && input.Contains(keyword))
        {
            foundResult = int.TryParse(string.Concat(input
                .Substring(input.IndexOf(keyword) + keyword.Length)
                .TakeWhile(char.IsDigit)), out result);
        }
        return foundResult;
    }
