        public class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Blah == y.Blah;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.Blah.GetHashCode();
        }
    }
