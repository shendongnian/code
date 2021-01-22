        public static T FromEnumStringValue<T>(this string description) where T : struct {
            Debug.Assert(typeof(T).IsEnum);
            return typeof(T)
                .GetFields()
                .Where(f => f.GetCustomAttributes(typeof(StringValueAttribute), false)
                             .Cast<StringValueAttribute>()
                             .Any(a => a.Value.Equals(description, StringComparison.OrdinalIgnoreCase))
                )
                .Select(f => (T)f.GetValue(f))
                .First();
        }
