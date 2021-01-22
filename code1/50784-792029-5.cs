    internal class ClassA
    {
        public ClassB Property { get; set; }
    }
    internal class ClassB
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Method()
        {
            return Property1 + Property2;
        }
    }
