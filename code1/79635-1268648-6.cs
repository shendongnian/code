    private static bool IsTextAllowed(string text)
    {
        Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        return !regex.IsMatch(text);
    }
