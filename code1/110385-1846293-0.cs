    class ClassA
    {
        public string Property1 { get; set; }
    }
    
    class ClassB
    {
        public string Property2 { get; set; }
    
        public static implicit operator ClassB(ClassA classA)
        {
            return new ClassB() { Property2 = classA.Property1 };
        }
    }
