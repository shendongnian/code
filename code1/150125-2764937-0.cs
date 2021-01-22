    class Class1
    {
        public object field1 = null;
        public virtual object Property1 { get; set; }
        public object Property2 { get; set; }
        public string Property3 { get; set; }
    }
    class Class2 : Class1
    {
        public new object field1 = null;
        public override object Property1 { get; set; }
        public new string Property3 { get; set; }
    }
    class Class3 : Class2
    {
        public new string Property3 { get; set; }
    }
