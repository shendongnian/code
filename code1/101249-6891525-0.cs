    class GeneratedObject : IObject
    {
        public string Value { get { return "Test"; } }
        public T Get<T>(string propertyName)
        {
            return Property<GeneratedObject>.Get<T>(this,propertyName);
        }
    }
