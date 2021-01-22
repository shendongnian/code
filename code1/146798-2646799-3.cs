    class Anonymous
    {
        public String Id { get; }
        public IEnumerable<AnonymousSubtype> Fields { get; }
    }
    
    class AnonymousSubtype
    {
       public String Id { get; }
       public String Value { get; }
    }
