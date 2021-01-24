    static void Main(string[] args)
    {
        // Populate dictionary with string binary key and associated char value
        Dictionary<String, char> binToAscii =
            Enumerable.Range(32, 1)               // Space character
                .Concat(Enumerable.Range(48, 10)) // Numbers
                .Concat(Enumerable.Range(65, 26)) // Uppercase Letters
                .Concat(Enumerable.Range(97, 26)) // Lowercase Letters
                .Select(intVal => (char) intVal)  // Convert int to char
                // And finally, set the value to the binary string of the char
                .ToDictionary(dataChar => Convert.ToString(dataChar, 2));
        var testString = "Hello World";
        var resultString = string.Join(" ", testString.Select(chr =>
            binToAscii.FirstOrDefault(x => x.Value == chr).Key ?? $"['{chr}' not found]"));
        Console.WriteLine($"{testString} == {resultString}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
