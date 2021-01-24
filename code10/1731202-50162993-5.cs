    /// <summary>
    /// Gets the index of the first duplicate item in an array
    /// </summary>
    /// <param name="a">The array to search</param>
    /// <returns>The index of the first duplicate item, or -1 if none exist</returns>
    public static int FirstDuplicate(int[] a)
    {
        if (a == null || a.Length < 2) return -1;
        var smallestDupeIndex = int.MaxValue;
        for (int i = 0; i < a.Length - 1 && i < smallestDupeIndex; i++)
        {
            for (int j = i + 1; j < a.Length && j < smallestDupeIndex; j++)
            {
                if (a[i] == a[j])
                {
                    smallestDupeIndex = j;
                }
            }
        }
        return smallestDupeIndex == int.MaxValue ? -1 : smallestDupeIndex;
    }
