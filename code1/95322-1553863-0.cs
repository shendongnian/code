    /// <summary>
    /// Check the given array is empty or not
    /// </summary>
    public static bool IsNotEmpty(this Array obj)
    {
        return ((obj != null)
            && (obj.Length > 0));
    }
    /// <summary>
    /// Check the given ArrayList is empty or not
    /// </summary>
    public static bool IsNotEmpty(this ArrayList obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given BitArray is empty or not
    /// </summary>
    public static bool IsNotEmpty(this BitArray obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given CollectionBase is empty or not
    /// </summary>
    public static bool IsNotEmpty(this CollectionBase obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given DictionaryBase is empty or not
    /// </summary>
    public static bool IsNotEmpty(this DictionaryBase obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given Hashtable is empty or not
    /// </summary>
    public static bool IsNotEmpty(this Hashtable obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given Queue is empty or not
    /// </summary>
    public static bool IsNotEmpty(this Queue obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given ReadOnlyCollectionBase is empty or not
    /// </summary>
    public static bool IsNotEmpty(this ReadOnlyCollectionBase obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given SortedList is empty or not
    /// </summary>
    public static bool IsNotEmpty(this SortedList obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given Stack is empty or not
    /// </summary>
    public static bool IsNotEmpty(this Stack obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
    /// <summary>
    /// Check the given generic is empty or not
    /// </summary>
    public static bool IsNotEmpty<T>(this ICollection<T> obj)
    {
        return ((obj != null)
            && (obj.Count > 0));
    }
