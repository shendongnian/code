    /// <summary>
    ///     Clears the contents of the string builder.
    /// </summary>
    /// <param name="value">
    ///     The <see cref="StringBuilder"/> to clear.
    /// </param>
    public static void Clear(this StringBuilder value)
    {
        value.Length = 0;
        value.Capacity = 0;
    }
