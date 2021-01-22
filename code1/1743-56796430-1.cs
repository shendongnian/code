public static class EnumHelpers
{
    /// <summary>
    /// Returns whether the given enum value is a defined value for its type.
    /// </summary>
    public static bool IsDefined<T>(this T enumValue)
        where T : Enum
        => EnumValueCache<T>.DefinedValues.Contains(enumValue);
    /// <summary>
    /// Caches the defined values for each enum type for which this class is accessed.
    /// </summary>
    private static class EnumValueCache<T>
        where T : Enum
    {
        public static readonly HashSet<T> DefinedValues = new HashSet<T>((T[])Enum.GetValues(typeof(T)));
    }
}
Usage:
if (!myEnumValue.IsDefined())
   // ...
