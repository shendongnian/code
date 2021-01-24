    static void Main(string[] args)
    {
        // Populate dictionary with string binary key and associated char value
        Dictionary<String, char> binToAscii =
            Enumerable.Range(32, 1)               // Space character
                .Concat(Enumerable.Range(48, 10)) // Numbers
                .Concat(Enumerable.Range(65, 26)) // Uppercase Letters
                .Concat(Enumerable.Range(97, 26)) // Lowercase Letters
                .Select(intVal => (char) intVal)  // Convert int to char
                // And finally, set the key to the binary string, padded to 8 characters
                .ToDictionary(dataChar => Convert.ToString(dataChar, 2).PadLeft(8, '0'));
        var testString = "Hello @ World";
        // Display the binary representation of each character or [--char--] if missing
        var resultString = string.Join(" ", testString.Select(chr =>
            binToAscii.FirstOrDefault(x => x.Value == chr).Key ?? $"[--'{chr}'--]"));
        Console.WriteLine($"{testString} ==\n{resultString}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
