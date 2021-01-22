    class Foo
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }    
    class FooComparer : IEqualityComparer<Foo>
    {
        public FooComparer(Func<Foo, Foo, bool> equalityComparer, Func<Foo, int> getHashCode)
        {
            EqualityComparer = equalityComparer;
            HashCodeGenerator = getHashCode;
        }
    
        Func<Foo, Foo, bool> EqualityComparer;
        Func<Foo, int> HashCodeGenerator;
    
        public bool Equals(Foo x, Foo y)
        {
            return EqualityComparer(x, y);
        }
    
        public int GetHashCode(Foo obj)
        {
            return HashCodeGenerator(obj);
        }
    }
...
    List<Foo> foos = new List<Foo>() { new Foo() { Name = "A", Id = 4 }, new Foo() { Name = "B", Id = 4 } };
    var list1 = foos.Distinct(new FooComparer((x, y) => x.Id == y.Id, f => f.Id.GetHashCode()));
