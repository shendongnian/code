    class MyKey  : IEquatable<MyKey>
    {
        public int x;
        public string y;
        public bool Equals(MyKey other)
        {
            return other != null && x == other.x && y == other.y;
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();  // for example
        }
    }
    Dictionary<MyKey, Foo>  dict;
