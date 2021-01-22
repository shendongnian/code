    /// <summary>
    /// Reverse a String
    /// </summary>
    /// <param name="input">The string to Reverse</param>
    /// <returns>The reversed String</returns>
    public static string Reverse(this string input)
    {
        char[] array = input.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
