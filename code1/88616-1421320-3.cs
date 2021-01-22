        public bool Equals(EqualityTest other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.A, A) && Equals(other.B, B);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(EqualityTest))
            {
                return false;
            }
            return Equals((EqualityTest)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((A != null ? A.GetHashCode() : 0)*397) ^ (B != null ? B.GetHashCode() : 0);
            }
        }
        public static bool operator ==(EqualityTest left, EqualityTest right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(EqualityTest left, EqualityTest right)
        {
            return !Equals(left, right);
        }
