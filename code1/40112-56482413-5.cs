    public class TestEnum : EnumType<TestEnum> 
    {
    
        private TestEnum(string value) : base(value)
        {}
        public static TestEnum Test1 { get { return new TestEnum("TEST1"); } }
        public static TestEnum Test2 { get { return new TestEnum("TEST2"); } }
    }
