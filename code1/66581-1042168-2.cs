        public bool Equals(ClauseBE other)
        {
            if (this._id == other._id)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }
            if (!(obj is ClauseBE))
            {
                throw new InvalidCastException("The 'obj' argument is not a ClauseBE object.");
            }
            return Equals(obj as ClauseBE);
        }
        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }
        public static bool operator ==(ClauseBE a, ClauseBE b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
    
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
    
            return a.Equals(b);
        }
    
        public static bool operator !=(ClauseBE a, ClauseBE b)
        {
            return !(a == b);
        }
