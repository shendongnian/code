    class MyObjectEqualityComparer : IEqualityComparer<MyObject>
    {
        MyObjectEqualityComparer()
        {
        }
        public static readonly MyObjectEqualityComparer Default = new MyObjectEqualityComparer();
        public bool Equals(MyObject x, MyObject y)
        {
            return x.Id1 == y.Id1 && x.Id2 == y.Id2 && x.Id3 == y.Id3;
        }
        public int GetHashCode(MyObject obj)
        {
            return obj.Id1.GetHashCode() ^ obj.Id2.GetHashCode() ^ obj.Id3.GetHashCode();
        }
    }
