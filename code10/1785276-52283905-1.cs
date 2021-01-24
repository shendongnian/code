    class Foo : IBaz
    {
        public string BazFoo { get; set; }
        public string GetBaz() => BazFoo;
    }
    
    class Bar : IBaz
    {
        public string BazBar { get; set; }
        public string GetBaz() => BazBar;
    }
