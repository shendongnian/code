    public class SparseArray<T>
    {
        private Dictionary<int, T> values = new Dictionary<int, T>();
        private T defaultValue;
        public SparseArray(T defaultValue)
        {
            this.defaultValue = defaultValue;
        }
        public T this [int index]
        {
          set { values[index] = value; }
          get { return values.ContainsKey(index) ? values[index] ? defaultValue; }
        }
    }
