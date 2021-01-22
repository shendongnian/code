    class EqualThingTester : IEqualityComparer<Thing>
    {
        public bool Equals(Thing x, Thing y)
        {
            return x.ParentID.Equals(y.ParentID);
        }
        public int GetHashCode(Thing obj)
        {
            return obj.ParentID.GetHashCode();
        }
    }
