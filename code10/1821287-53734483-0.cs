        protected bool Equals(Function other)
        {
            return string.Equals(Name, other.Name) && string.Equals(RT, other.RT) && ParamCount == other.ParamCount && Equals(ParamDT, other.ParamDT);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Function) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RT != null ? RT.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ParamCount;
                hashCode = (hashCode * 397) ^ (ParamDT != null ? ParamDT.GetHashCode() : 0);
                return hashCode;
            }
        }
