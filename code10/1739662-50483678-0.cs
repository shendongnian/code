    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MapToAttribute : Attribute
    {
        public readonly char Key;
        public MapToAttribute(char key)
        {
            Key = key;
        }
    }
    public class MapToUtilities<T>
    {
        private static readonly Tuple<T, char>[] KeyValues = Init();
        private static Tuple<T, char>[] Init()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(nameof(T));
            }
            T[] values = (T[])Enum.GetValues(typeof(T));
            Enum.
            var valuesWithKeys = from x in values
                                     
            return valuesWithKeys.ToArray();
        }
    }
