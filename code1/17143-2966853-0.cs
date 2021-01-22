    /// <summary>
    /// Gets the case-insensitive <paramref name="key"/> from <paramref name="dictionary"/>.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key to search .</param>
    /// <returns>An existing key; or <see cref="string.Empty"/> if not found.</returns>
    public static string GetKeyIgnoringCase<T>(this IDictionary<string, T> dictionary, string key)
    {
        if (string.IsNullOrEmpty(key)) return string.Empty;
        foreach (var kvp in dictionary)
        {
            if (kvp.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
            {
                return kvp.Key;
            }
        }
        return string.Empty;
    }
