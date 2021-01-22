    public static int GetIntValue(this Enum e)
    {
        return e.GetValue<int>();
    }
    public static T GetValue<T>(this Enum e) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        return (T)(object)e;
    }
