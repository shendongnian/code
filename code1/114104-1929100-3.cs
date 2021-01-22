    public abstract AbstractParameter
    { 
        public string Name { get; protected set; } 
        public string Value { get; protected set; }
    }
    class Descriptor
    {
        public string Name { get; private set; }
        public IList<AbstractParameter> Parameters { get; private set; }
    
        private Descriptor() { }
        public Descriptor GetByName(string Name) { ... }
        private class NestedParameter : AbstractParameter
        {
            public NestedParameter() { /* whatever goes here */ }
        }
    }
