    /// <summary>
    /// Gets the column letter(s) corresponding to the given column number.
    /// </summary>
    /// <param name="column">The one-based column index. Must be greater than zero.</param>
    /// <returns>The desired column letter, or an empty string if the column number was invalid.</returns>
    public static string GetColumnLetter(int column) {
        if (column < 1) return String.Empty;
        return GetColumnLetter((column - 1) / 26) + (char)('A' + (column - 1) % 26);
    }
