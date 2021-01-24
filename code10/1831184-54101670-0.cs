    static string GetString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    static int GetInt(string prompt)
    {
        int result;
        while (!int.TryParse(GetString(prompt), out result)) ; // Empty while loop body
        return result;
    }
