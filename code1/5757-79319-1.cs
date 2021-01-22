    internal sealed class GenericTypeThatRequiresAnEnum<T> {
        static GenericTypeThatRequiresAnEnum() {
            if (!typeof(T).IsEnum) {
            throw new ArgumentException("T must be an enumerated type");
            }
        }
    }
