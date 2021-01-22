    public class UniqueIdMapper
    {
        private class ObjectEqualityComparer : IEqualityComparer<object>
        {
            public bool Equals(object x, object y)
            {
                return object.ReferenceEquals(x, y);
            }
            public int GetHashCode(object obj)
            {
                return RuntimeHelpers.GetHashCode(obj);
            }
        }
        private Dictionary<object, Guid> dict = new Dictionary<object, Guid>(new ObjectEqualityComparer());
        public Guid GetUniqueId(object o)
        {
            Guid id;
            if (!dict.TryGetValue(o, out id))
            {
                id = Guid.NewGuid();
                dict.Add(o, id);
            }
            return id;
        }
    }
