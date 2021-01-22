    /// <summary>
    /// same as python 'join'
    /// </summary>
    /// <typeparam name="T">list type</typeparam>
    /// <param name="separator">string separator </param>
    /// <param name="list">list of objects to be ToString'd</param>
    /// <returns>a concatenated list interleaved with separators</returns>
    static public string Join<T>(this string separator, IEnumerable<T> list)
    {
        var sb = new StringBuilder();
        bool first = true;
    
        foreach (T v in list)
        {
            if (!first)
                sb.Append(separator);
            first = false;
    
            if (v != null)
                sb.Append(v.ToString());
        }
    
        return sb.ToString();
    }
