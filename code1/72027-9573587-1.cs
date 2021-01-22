    /// <summary>
    /// Converts a string to byte array
    /// </summary>
    /// <param name="input">The string</param>
    /// <returns>The byte array</returns>
    public static byte[] ConvertToByteArray(string input)
    {
        return input.Select(Convert.ToByte).ToArray();
    }
    /// <summary>
    /// Converts a byte array to a string
    /// </summary>
    /// <param name="bytes">the byte array</param>
    /// <returns>The string</returns>
    public static string ConvertToString(byte[] bytes)
    {
        return new string(bytes.Select(Convert.ToChar).ToArray());
    }
    /// <summary>
    /// Converts a byte array to a string
    /// </summary>
    /// <param name="bytes">the byte array</param>
    /// <returns>The string</returns>
    public static string ConvertToBase64String(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
