    /// <summary>
    /// Checks if string contains only letters a-z and A-Z and should not be more than 25 characters in length
    /// </summary>
    /// <param name="value">String to be matched</param>
    /// <returns>True if matches, false otherwise</returns>
    public static bool IsValidString(string value)
    {
        string pattern = @"^[a-zA-Z]{1,25}$";
        return Regex.IsMatch(value, pattern);
    }
