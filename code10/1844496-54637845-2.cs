    class MyClass<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public T Item { get; set; }
    }
    var o = new MyClass<SomeThirdPartyClass>
    {
        Item = new SomeThirdPartyClass()
    };
    o.Name = "name";            //Custom property
    o.Item.Foo = new object();  //Base property
    
   
