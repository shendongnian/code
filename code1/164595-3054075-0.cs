    /// <summary>
    /// Concatenates a separator between each element of a string enumeration.
    /// </summary>
    /// <param name="source">The string enumeration.</param>
    /// <param name="separator">The separator string. This may not be null.</param>
    /// <returns>The concatenated string.</returns>
    public static string Join(this IEnumerable<string> source, string separator)
    {
        StringBuilder ret = new StringBuilder();
        bool first = true;
        foreach (string str in source)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                ret.Append(separator);
            }
            ret.Append(str);
        }
        return ret.ToString();
    }
    /// <summary>
    /// Concatenates a sequence of strings.
    /// </summary>
    /// <param name="source">The sequence of strings.</param>
    /// <returns>The concatenated string.</returns>
    public static string Join(this IEnumerable<string> source)
    {
        return source.Join(string.Empty);
    }
