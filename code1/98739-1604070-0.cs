    [AttributeUsage(AttributeTargets.Method)]
    class TestAttribute : Attribute
    {
        public TestAttribute(params string[] aliases)
        {
            allowedAliases = aliases;
        }
    
        public string[] allowedAliases { get; set; }
    
    }
