    class SomeAttr : Attribute
    {
        private Type _type;
    
        public SomeAttr(Type type)
        {
            _type = type;
        }
    
        private void Method()
        {
            string s = _type.ToString(); // Example usage of type.
        }
    }
