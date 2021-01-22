    /// <summary>
    /// Gets the key using <paramref name="caseInsensitiveKey"/> from <paramref name="dictionary"/>.
    /// </summary>
    /// <typeparam name="T">The dictionary value.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="caseInsensitiveKey">The case insensitive key.</param>
    /// <returns>
    /// An existing key; or <see cref="string.Empty"/> if not found.
    /// </returns>
    public static string GetKeyIgnoringCase<T>(this IDictionary<string, T> dictionary, string caseInsensitiveKey)
    {
        if (string.IsNullOrEmpty(caseInsensitiveKey)) return string.Empty;
        foreach (string key in dictionary.Keys)
        {
            if (key.Equals(caseInsensitiveKey, StringComparison.InvariantCultureIgnoreCase))
            {
                return key;
            }
        }
        return string.Empty;
    }
