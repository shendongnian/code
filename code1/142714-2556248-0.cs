    class Foo
    {
        public string Blah { get; set; }
    }
    
    class FooComparer : IEqualityComparer<Foo>
    {
        #region IEqualityComparer<Foo> Members
    
        public bool Equals(Foo x, Foo y)
        {
            return x.Blah.Equals(y.Blah);
        }
    
        public int GetHashCode(Foo obj)
        {
            return obj.Blah.GetHashCode();
        }
    
        #endregion
    }
...
    Foo foo = new Foo() { Blah = "Apple" };
    Foo foo2 = new Foo() { Blah = "Apple" };
    
    List<Foo> foos = new List<Foo>();
    
    foos.Add(foo);
    if (!foos.Contains(foo2, new FooComparer()))
        foos.Add(foo2);
