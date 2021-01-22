    class ImmutableType
    {
        public string Test
        {
            get; // No Set at all, not even a private set.
        }
    
        public ImmutableType(string test)
        {
            Test = test; // The compiler understands this and initializes the backing field
        }
    }
