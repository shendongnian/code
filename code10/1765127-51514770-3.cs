        public bool Equals(Item other)
        {
            return A == other?.A && B == other.B && C == other.C;
        }
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + A.GetHashCode();
            hash = (hash * 7) + B.GetHashCode();
            hash = (hash * 7) + C.GetHashCode();
            return hash;
        }
