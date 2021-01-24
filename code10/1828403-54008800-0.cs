    public static class SomeRegexConsts
    {
        private const string Name = "[A-Z][a-z]+";
        private const string Surname = "[A-Z][a-z]+";
    
        public static readonly string FullName = $"{Name} {Surname}";
    
    }
