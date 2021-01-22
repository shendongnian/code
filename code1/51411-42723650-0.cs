    public class ObservableKvp<K, V> : BindableBase
    {
        public K Key { get; }
        private V _value;
        public V Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        public ObservableKvp(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
