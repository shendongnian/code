    public class ReadOnlyIndexedProperty<TIndex, TValue>
    {
        readonly Func<TIndex, TValue> GetFunc;
        public ReadOnlyIndexedProperty(Func<TIndex, TValue> getFunc)
        {
            this.GetFunc = getFunc;
        }
        public TValue this[TIndex i]
        {
            get
            {
                return GetFunc(i);
            }
        }
    }
