    static string ReplaceWithIncrementingNumber(string input, string find, string partToReplace)
    {
        if (input == null || find == null ||
            partToReplace == null || !find.Contains(partToReplace))
        {
            return input;
        }
        // Get the index of the first occurrence of our 'find' string
        var index = input.IndexOf(find);
        // Track the number of occurrences we've found, to use as a replacement string
        var counter = 1;
        while (index > -1)
        {
            // Get the leading string up to '*', add the counter, then add the trailing string
            input = input.Substring(0, index) +
                    find.Replace(partToReplace, $"{counter++}.") +
                    input.Substring(index + find.Length);
            // Find the next occurrence of our 'find' string
            index = input.IndexOf(find, index + find.Length);
        }
        return input;
    }
