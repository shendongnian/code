    private static readonly Random _rand = new Random();
    /// <summary>
    /// Generate a random string.
    /// </summary>
    /// <param name="length">The length of random string. The minimum length is 3.</param>
    /// <returns>The random string.</returns>
    public string RandomString(int length)
    {
        length = Math.Max(length, 3);
        byte[] bytes = new byte[length];
        _rand.NextBytes(bytes);
        return Convert.ToBase64String(bytes).Substring(0, length);
    }
