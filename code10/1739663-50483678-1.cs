    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MapToAttribute : Attribute
    {
        public readonly string Key;
        public MapToAttribute(string key)
        {
            Key = key;
        }
    }
    public static class MapToUtilities<T> where T : struct
    {
        private static readonly Dictionary<string, T> keyValues = Init();
        private static Dictionary<string, T> Init()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(nameof(T));
            }
            var values = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            var keyValues2 = new Dictionary<string, T>();
            foreach (FieldInfo fi in values)
            {
                var attr = fi.GetCustomAttribute<MapToAttribute>();
                if (attr == null)
                {
                    continue;
                }
                string key = attr.Key;
                T value = (T)fi.GetValue(null);
                keyValues2.Add(key, value);
            }
            return keyValues2;
        }
        public static T KeyToValue(string key)
        {
            return keyValues[key];
        }
        public static string ValueToKey(T value)
        {
            var cmp = EqualityComparer<T>.Default;
            return keyValues.First(x => cmp.Equals(x.Value, value)).Key;
        }
    }
