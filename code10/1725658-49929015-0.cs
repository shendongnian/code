    internal class CommonProperty {
        public string Name { get; set; }
        public PropType Type { get; set; }
        public List<T> GetPossibleValues<T> { get; set; }
        private object _value;
        public T GetValue<T>() {
            return (T)_value;
        }
        public void SetValue<T>(T val) {
            _value = val;
        }
    }
