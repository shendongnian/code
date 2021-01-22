    class DescriptiveName1 {
        public Baz Baz { get; set; }
        public List<Wrgl> Wrgls { get; set; }
    }
    class DescriptiveName2 : Dictionary<Bar, DescriptiveName1> { }
    class DescriptiveName3 : Dictionary<Foo, DescriptiveName2> { }
    class DescriptiveName3Item : KeyValuePair<Foo, DescriptiveName2> { }
    var myClass = new MyClass<DescriptiveName3Item>(new DescriptiveName3());
