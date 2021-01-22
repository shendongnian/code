        class FooComparer : IEqualityComparer<Foo>
    {
        
        public bool Equals(Foo x, Foo y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.GetHashCode();
        }
    }
