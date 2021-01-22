    public class Example<T> {
        private static readonly Predicate<T> isDefault;
        static Example() {
            // Nullability check is a bit ugly, but we do it once per T,
            // so what the heck...
            if (typeof(T).IsValueType &&
               (!typeof(T).IsGenericType
            ||  typeof(T).GetGenericTypeDefinition() != typeof(Nullable<>)
            )) {
                // This is safe because T is not null
                isDefault = val => default(T).Equals(val);
            } else {
                // T is not a value type, so its default is null
                isDefault = val => val == null;
            }
        }
        public bool Check(T value) {
            // Now our null-checking is both good-looking and efficient
            return isDefault(value);
        }
    }
