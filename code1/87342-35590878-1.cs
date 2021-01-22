    public static class Enums<T>
      where T : struct, IComparable, IFormattable, IConvertible
    {
      static Enums()
      {
        if (!typeof(T).IsEnum)
          throw new ArgumentException("Type T must be an Enum type");  
      }
      public static IEnumerable<T> GetValues()
      {
        var result = ((T[])Enum.GetValues(typeof(T)).ToList()
        return result;
      }
    }
