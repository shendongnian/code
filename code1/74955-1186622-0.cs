    public class Invalid
    {
        public Nested Nested { get { return null; } }        
        public class Nested {}
    }
    
    public class Valid
    {
        public Nested NestedFoo { get { return null; } }        
        public class Nested {}
    }
