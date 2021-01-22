    public static T[] GetEnumValues<T>() where T : struct, IComparable, IFormattable, IConvertible
    {
        if (typeof(T).BaseType != typeof(Enum))
        {
            throw new ArgumentException(string.Format("{0} is not of type System.Enum", typeof(T)));
        }
        return Enum.GetValues(typeof(T)) as T[];
    }
