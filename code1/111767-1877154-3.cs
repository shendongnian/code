    public abstract class Class1
    {
        // Fields
        [CompilerGenerated]
        private string <TestString>k__BackingField;
    
        // Methods
        protected Class1()
        {
        }
    
        // Properties
        public string TestString
        {
            [CompilerGenerated]
            get
            {
                return this.<TestString>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<TestString>k__BackingField = value;
            }
        }
    
        public abstract string TestStringAbstract { get; set; }
    }
