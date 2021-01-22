    public struct ValueWithIndex<T>
    {
        public readonly T Value;
        public readonly int Index;
        public ValueWithIndex(T value, int index)
        {
            this.Value = value;
            this.Index = index;
        }
        public static ValueWithIndex<T> Create(T value, int index)
        {
            return new ValueWithIndex<T>(value, index);
        }
    }
    public static class ExtensionMethods
    {
        public static IEnumerable<ValueWithIndex<T>> GetEnumeratorWithIndex<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(ValueWithIndex<T>.Create);
        }
    }
