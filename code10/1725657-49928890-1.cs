    // Consider making it abstract
    internal class CommonProperty
    {
        public string Name { get; set; }
        public PropType Type { get; set; }
    }
    internal class CommonProperty<T> : CommonProperty
    {
        public List<T> PossibleValues { get; set; }
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                // TODO: Is this really necessary?
                if (!_value.Equals(value))
                {
                    _value = value;
                }
            }
        }
    }
