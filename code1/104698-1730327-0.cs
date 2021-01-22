    /// <summary>
    /// Converts an array of integers into a string that may be used in a SQL IN expression.
    /// </summary>
    /// <param name="values">The array to convert.</param>
    /// <returns>A string representing the array as a parenthetical comma-delemited list. If the array
    /// is empty or missing, then "(null)" is returned.</returns>
    public static string ToSqlInList(int[] values)
    {
        if (values == null || values.Length == 0)
            return "(null)";  // In SQL the expression "IN (NULL)" is always false.
        return string.Concat("(", string.Join(",", Array.ConvertAll<int, string>(values,x=>x.ToString())), ")");
    }
