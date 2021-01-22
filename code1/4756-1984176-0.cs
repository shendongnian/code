    public struct IndexValue<T> {
        public int Index {get; private set;}
        public T Value {get; private set;}
        public IndexValue(int index, T value) : this() {
            this.Index = index;
            this.Value = value;
        }
    }
    public static class EnumExtension
    {
        public static IEnumerable<IndexValue<T>> KeyValuePairs<T>(this IList<T> list) {
            for (int i = 0; i < list.Count; i++)
                yield return new IndexValue<T>(i, list[i]);
        }
    }
