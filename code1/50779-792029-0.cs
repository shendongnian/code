    internal class ClassA
    {
        public ClassB Property { get; set; }
        public int Method()
        {
            var classB = Property;
            return classB.Property1 + classB.Property2;
        }
    }
    internal class ClassB
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
    }
