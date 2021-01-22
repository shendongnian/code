    class A
    {
        [Foo]
        public int Property1{get; set;}
        public int Property2{get {return variable;} set{ Property1 = value; variable = value; }
    }
