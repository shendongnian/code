    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    class DependsOnAttribute : Attribute
    {
        public DependsOnAttribute(params string[] properties)
        {
            Properties = properties;
        }
        public DependsOnAttribute(Type type, params string[] properties)
            : this(properties)
        {
            Type = type;
        }
        public string[] Properties { get; }
        // We now also can store the type of the PropertyChanged event source
        public Type Type { get; }
    }
