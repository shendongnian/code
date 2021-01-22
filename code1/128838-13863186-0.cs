    /// <summary>
    /// Converts the string representation of the name or numeric value of one or
    //  more enumerated constants to an equivalent enumerated object.
    /// </summary>
    /// <typeparam name="TEnum">An enumeration type.</typeparam>
    /// <param name="value">A string containing the name or value to convert.</param>
    /// <returns>An object of type TEnum whose value is represented by value</returns>
    /// <exception cref="System.ArgumentNullException">enumType or value is null.</exception>
    /// <exception cref=" System.ArgumentException"> enumType is not an System.Enum. -or- 
    /// value is either an empty string or only contains white space.-or- 
    /// value is a name, but not one of the named constants defined for the enumeration.</exception>
    /// <exception cref="System.OverflowException">value is outside the range of the underlying type of enumType.</exception>
    public static TEnum Parse<TEnum>(String value) where TEnum : struct
    {
       return (TEnum)Enum.Parse(typeof(TEnum), value);
    }
