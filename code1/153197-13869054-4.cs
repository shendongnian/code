        public static T FromEnumStringValue<T>(this string description) where T : struct {
            Debug.Assert(typeof(T).IsEnum);
            return (T)typeof(T)
                .GetFields()
                .First(f => f.GetCustomAttributes<StringValueAttribute>()
                             .Any(a => a.Value.Equals(description, StringComparison.OrdinalIgnoreCase))
                )
                .GetValue(null);
        }
