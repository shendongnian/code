    public class NullableParsable
    {
        private static readonly Dictionary<string, Func<string, object>> _parsers =
            new Dictionary<string, Func<string, object>>();
        public static void Register<T>(Func<string, T?> unknown)
            where T : struct
        {
            var key = typeof(T).FullName;
            _parsers.Add(key, x => unknown(x));
        }
        public static T? Parse<T>(string t)
            where T : struct
        {
            var key = typeof(T).FullName;
            if (_parsers.TryGetValue(key, out var parser))
            {
                if (string.IsNullOrEmpty(t))
                {
                    return null;
                }
                return (T?) parser(t);
            }
            throw new NotSupportedException("Not sure how to map this type");
        }
    }
