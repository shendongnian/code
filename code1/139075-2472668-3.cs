    public class SomeClass
    {
        [Flags]
        public enum Days
        {
            None = 0,
            Monday = 1,
            // and so on
        }
    }
    
    public class SomeOtherClass
    {
        public SomeClass.Days SomeDays { get; set; }
    }
