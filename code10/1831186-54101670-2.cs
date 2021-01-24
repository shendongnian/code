    static string GetString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine(); // Return the result of the call to ReadLine directly
    }
    static int GetInt(string prompt)
    {
        int result;
        while (!int.TryParse(GetString(prompt), out result)) ; // Empty while loop body
        return result;
    }
