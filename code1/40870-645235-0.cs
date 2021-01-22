    /// <summary>
    /// Will parse and string value and return the Enum given.  Case is ignored when doing the parse.
    /// </summary>
    /// <param name="typeOfEnum">The type of the Enum to Parse</param>
    /// <param name="value">The string value for the result of the Enum</param>
    /// <param name="errorValue">If an error is encountered this value is returned.  (For example could be an Enum)</param>
    /// <returns>Returns Enum Object</returns>
    public static T ToEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
