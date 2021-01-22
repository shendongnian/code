    public class ExampleCollection<T> : Collection<T>
    {
        public IndexedProperty<int, T> ExampleProperty
        {
            get
            {
                return new IndexedProperty<int, T>(GetIndex, SetIndex);
            }
        }
        private T GetIndex(int index)
        {
            return this[index];
        }
        private void SetIndex(int index, T value)
        {
            this[index] = value;
        }
    }
