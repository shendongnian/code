    private static string GetLineBefore(string lineToFind, string[]lines)
    {
        if (lines != null && !string.IsNullOrEmpty(lineToFind))
        {
            // Start at the second line (index 1) since there is no line before the first
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Equals(lineToFind, StringComparison.OrdinalIgnoreCase))
                {
                    // Since 'i' represents the index of the first line, we
                    // return the item at index 'i - 1' to get the previous one
                    return lines[i - 1];
                }
            }
        }
        return null;
    }
