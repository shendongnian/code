    /// <summary>
    /// Returns the names of the properties that are not equal on a and b.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>An array of names of properties with distinct 
    ///          values or null if a and b are null or not of the same type
    /// </returns>
    public static string[] GetDistinctProperties(object a, object b) {
        if (object.ReferenceEquals(a, b))
            return null;
        if (a == null)
            return null;
        if (b == null)
            return null;
        var aType = a.GetType();
        var bType = b.GetType();
        if (aType != bType)
            return null;
        var props = aType.GetProperties();
        if (props.Any(prop => prop.GetIndexParameters().Length != 0))
            throw new ArgumentException("Types with index properties not supported");
        return props
            .Where(prop => !Equals(prop.GetValue(a, null), prop.GetValue(b, null)))
            .Select(prop => prop.Name).ToArray();
    } 
