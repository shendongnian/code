    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    class DependsOn : Attribute
    {
        public DependsOn(params string[] properties)
        {
            this.Properties = properties;
        }
        public DependsOn(Type type, params string[] properties)
            : this(properties)
        {
            Type = type;
        }
        public string[] Properties { get; private set; }
        // We now also can store the type of the PropertyChanged event source
        public Type Type { get; }
    }
