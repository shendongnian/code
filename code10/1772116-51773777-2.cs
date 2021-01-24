    private static string GetLineBefore(string lineToFind, string[] lines)
    {
        // Argument validation to avoid NullReferenceException or unnecessary search
        if (lines != null && !string.IsNullOrEmpty(lineToFind))
        {
            // Start at the second line (index 1) since there is no line before the first
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Equals(lineToFind, StringComparison.OrdinalIgnoreCase))
                {
                    // Since 'i' represents the index of the first line that we were
                    // searching for, we return the previous item, at index 'i - 1'
                    return lines[i - 1];
                }
            }
        }
        // If we never found our first line, return null to indicate no results
        return null;
    }
