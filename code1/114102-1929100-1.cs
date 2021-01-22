    interface IParameter
    { 
        string Name { get; } 
        string Value { get; }
    }
    class Descriptor
    {
        public string Name { get; private set; }
        public IList<IParameter> Parameters { get; private set; }
    
        private Descriptor() { }
        public Descriptor GetByName(string Name) { ... }
        class Parameter : IParameter
        {
            public string Name { get; private set; }
            public string Value { get; private set; }
        }
    }
