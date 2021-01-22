    class ClassA
    {		{
        public string Property1 { get; set; }
    
        public static explicit operator ClassB(ClassA classA)
        {
            return new ClassB() { Property2 = classA.Property1 };
        }
    }
    
    class ClassB
    {
        public string Property2 { get; set; }
    }
