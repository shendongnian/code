    class MyClass : SomeThirdPartyClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    //Example use
    var o = new MyClass();
    o.Name = "Name";           //Custom property
    o.Foo = new object();      //Base property
