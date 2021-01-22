    public struct IdPair : IEquatable<IdPair>
    {
        // ...
        public override bool Equals(object obj)
        {
            if (obj is IdPair)
                return Equals((IdPair)obj);
            return false;
        }
        public bool Equals(IdPair other)
        {
            return id1.Equals(other.id1)
                && id2.Equals(other.id2);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 269;
                hash = (hash * 19) + id1.GetHashCode();
                hash = (hash * 19) + id2.GetHashCode();
                return hash;
            }
        }
    }
