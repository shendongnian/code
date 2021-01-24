    private static List<string> GetMultiLineStringFromUser(string prompt)
    {
        Console.Write(prompt);
        // Create a list and add the first line to it
        List<string> results = new List<string> { Console.ReadLine() };
        // KeyAvailable will return 'true' if there is more input in the buffer
        // so we keep adding the lines until there are none left
        while(Console.KeyAvailable)
        {
            results.Add(Console.ReadLine());
        }
        // Return the list of lines
        return results;
    }
