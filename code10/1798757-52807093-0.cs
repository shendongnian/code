    public class MerkmalRowComparer : IEqualityComparer<MerkmalRow>
    {
        bool IEqualityComparer<MerkmalRow>.Equals(MerkmalRow x, MerkmalRow y)
        {
            // reference equality
            if (ReferenceEquals(x, y)) return true;
            
            // check for null
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            
            // check if each property is the same value
            return x.Name == y.Name && x.Wert == y.Wert;
        }
        int IEqualityComparer<MerkmalRow>.GetHashCode(MerkmalRow obj)
        {
            unchecked
            {
                var hashCode = obj.Name != null ? obj.Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (obj.Wert != null ? obj.Wert.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
