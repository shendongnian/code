    /// <summary>
    /// Replace "Enumerable.Range(n)" with "n.Range()":
    /// </summary>
    /// <param name="n">iterations</param>
    /// <returns>0..n-1</returns>
    public static IEnumerable<int> Range(this int n)
    {
        for (int i = 0; i < n; i++)
            yield return i;
    }
