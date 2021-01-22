    public interface IConfigurationItem<out T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }
