    /// <summary>
    /// Emulates VB Right Function
    /// Returns a string containing a specified number of characters from the right side of a string.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="length">The number of characters to return.</param>
    /// <returns>
    /// The right <paramref name="length"/> number of characters from the string.
    /// If the string has less than or equal to <paramref name="length"/> number of characters,
    /// an empty string is returned.
    /// </returns>
    public static string Right(this string s, int length)
    {
        return length > s.Length ? string.Empty : s.Substring(s.Length - length);
    }
