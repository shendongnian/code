    /// <summary>
    /// Converts the string array of IDs from the string to a long array.
    /// </summary>
    ///
    /// <param name="str">The string.</param>
    ///
    /// <returns>The array of IDs as long values.</returns>
    private static long[] ConvertStringArrayToLongArray(string str)
    {
        return str.Select(x => long.Parse(x.ToString())).ToArray();
    }
