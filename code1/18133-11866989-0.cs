    /// <summary>
    /// Searches in the haystack array for the given needle using the default equality operator and returns the index at which the needle starts.
    /// </summary>
    /// <typeparam name="T">Type of the arrays.</typeparam>
    /// <param name="haystack">Sequence to operate on.</param>
    /// <param name="needle">Sequence to search for.</param>
    /// <returns>Index of the needle within the haystack or -1 if the needle isn't contained.</returns>
    public static IEnumerable<int> IndexOf<T>(this T[] haystack, T[] needle)
    {
        if ((needle != null) && (haystack.Length >= needle.Length))
        {
            for (int l = 0; l < haystack.Length - needle.Length + 1; l++)
            {
                if (!needle.Where((data, index) => !haystack[l + index].Equals(data)).Any())
                {
                    yield return l;
                }
            }
        }
    }
