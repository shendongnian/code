    public class Foo
    {
        public Guid ID { get; set; }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public Lazy<SubFoo> SubFoo{ get; }
    }
    
    public class SubFoo
    {
        public IEnumerable<Bar> Prop3 { get; }
        public IEnumerable<Bar2> Prop4 { get; }
    }
