    // uglified code to fit within horizontal limits
    public static string InsertAtIndices
    (this string original, string insertion, params int[] insertionPoints) {
        var mutable = new StringBuilder(original);
        var validInsertionPoints = insertionPoints
            .Distinct()
            .Where(i => i >= 0 && i < original.Length)
            .OrderByDescending(i => i);
        foreach (int insertionPoint in validInsertionPoints)
            mutable.Insert(insertionPoint, insertion);
        return mutable.ToString();
    }
