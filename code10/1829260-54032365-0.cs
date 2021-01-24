    class TestClass
    {
        public string example { get; set; }
        public NestedClass nestedclass { get; set; }
    
        public TestClass ()
        {
            nestedclass = new NestedClass();
        }
