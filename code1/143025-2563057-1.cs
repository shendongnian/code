    class Foo
    {
        public IList<object> Bar { get; set; }
    }
...
    Foo foo = new Foo();
    foo.Bar = new List<object>();
    foo.Bar.Add(1);
    foo.Bar.Add("a");
    
    Foo foo2 = new Foo();
    foo2.Bar = new List<object>();
    foo2.Bar.Add(2);
    foo2.Bar.Add('b');
    
    List<Foo> foos = new List<Foo>() { foo, foo2 };
    
    var query = from f in foos
                from b in f.Bar
                where !(b is string)
                select new
                {
                    InnerObjectType = b.GetType(),
                    InnerObject = b
                };
    
    foreach (var obj in query)
        Console.WriteLine("{0}\t{1}", obj.InnerObjectType, obj.InnerObject);
