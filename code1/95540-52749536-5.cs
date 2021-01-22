    /// <summary>
    /// Concatenates two or more arrays into a single one.
    /// </summary>
    public static T[] Concat<T>(params T[][] arrays)
    {
        // return (from array in arrays from arr in array select arr).ToArray();
    
        var result = new T[arrays.Sum(a => a.Length)];
        int offset = 0;
        for (int x = 0; x < arrays.Length; x++)
        {
            arrays[x].CopyTo(result, offset);
            offset += arrays[x].Length;
        }
        return result;
    }
