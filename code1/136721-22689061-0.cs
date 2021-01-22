    public class SelectList
    {
        public static IEnumerable<Enum> Of<T>() where T : struct, IConvertible
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                return Enum.GetValues(t).Cast<Enum>();
            }
            throw new ArgumentException("<T> must be an enumerated type.");
        }
    }
