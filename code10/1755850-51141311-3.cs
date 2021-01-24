    /// <summary>
    /// Returns a timespan from an input string that specifies minutes:seconds
    /// </summary>
    /// <param name="input">"minutes:seconds", where seconds can be a double</param>
    /// <returns>Timespan representation of the input string</returns>
    private static TimeSpan ParseMinSecMS(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("input cannot be null, empty, or whitespace");
        var parts = input.Split(':');
        var minutes = "00";
        string seconds;
        if (parts.Length > 1)
        {
            minutes = parts[0].PadLeft(2, '0');
            seconds = parts[1].PadRight(1, '0');
        }
        else
        {
            seconds = parts[0].PadRight(1, '0');
        }
        return TimeSpan.Parse($"0.00:{minutes}:{seconds}");
    }
