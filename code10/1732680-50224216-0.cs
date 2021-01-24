    /// <summary>
    /// Continually prompts the user for input until they enter a valid integer
    /// </summary>
    /// <param name="prompt">The question or request to display to the user</param>
    /// <returns>The integer value of the user's response</returns>
    private static int GetIntFromUser(string prompt)
    {
        int value;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out value));
        return value;
    }
