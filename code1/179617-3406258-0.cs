    /// <summary>
    /// Returns true if the value is represented in the provided enumeration.
    /// </summary>
    /// <typeparam name="T">Type of the value</typeparam>
    /// <param name="obj">The object to check if the enumeration contains</param>
    /// <param name="values">The enumeration that might contain the object</param>
    /// <returns>True if the object exists in the enumeration</returns>
    public static bool In<T>(this T obj, IEnumerable<T> values) {
        return values.Contains(obj);
    }
