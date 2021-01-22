    /// <summary>
    //     Returns a copy of this string converted to `Title Case`.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The `Title Case` equivalent of the current string.</returns>
    public static string ToTitleCase(this string value)
    {
        string result = string.Empty;
    
        for (int i = 0; i < value.Length; i++)
        {
            char p = i == 0 ? char.MinValue : value[i - 1];
            char c = value[i];
    
            result += char.IsLetter(c) && ((p is ' ') || p is char.MinValue) ? $"{char.ToUpper(c)}" : $"{char.ToLower(c)}";
        }
    
        return result;
    }
