    class EnumWrapper<T> where T : struct
    {
        private readonly T value;
        public T Value { get { return value; } }
        public EnumWrapper(T value) { this.value = value; }
        public string Description { get { return GetDescription<T>(value); } }
        public override string ToString() { return Description; }
    
        public static EnumWrapper<T>[] GetValues()
        {
            T[] vals = (T[])Enum.GetValues(typeof(T));
            return Array.ConvertAll(vals, v => new EnumWrapper<T>(v));
        }
    }
