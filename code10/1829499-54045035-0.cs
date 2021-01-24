    private static DateTime GetDateWithFormatFromUser(string prompt, 
        List<string> validFormats = null)
    {
        // If the user doesn't pass any valid formats, then use a generic method to get the value
        if (validFormats == null || validFormats.Count == 0) return GetDateFromUser(prompt);
        DateTime result;
        // Prompt the user in a loop, where the condition is
        // that the value they enter is in one of our formats.
        do
        {
            Console.Write(prompt);
        } while (!DateTime.TryParseExact(Console.ReadLine(), validFormats.ToArray(),
            CultureInfo.InvariantCulture, DateTimeStyles.None, out result));
        return result;
    }
    private static DateTime GetDateFromUser(string prompt)
    {
        DateTime result;
        do
        {
            Console.Write(prompt);
        } while (!DateTime.TryParse(Console.ReadLine(), out result));
        return result;
    }
