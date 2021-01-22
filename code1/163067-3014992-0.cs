    class KeyComparer : IEqualityComparer<Key>
    {
        public bool Equals(Key x, Key y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Key obj)
        {
            return obj.Name.GetHashCode ()
        }
    }
