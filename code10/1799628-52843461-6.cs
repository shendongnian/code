    public class MyProperty<T>
    {
        private T _value;
    
        public T Get() => _value;
    
        public T Set(T newValue) => _value = newValue;
    
        public string Name { get; set; }
    
        public bool AmReadable { get; set; }
    
        public bool AmWritable { get; set; }
    }
