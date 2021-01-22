    public class EqualityComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }
    
        public int GetHashCode(object obj)
        {
            return ((Key) obj).KeyString.GetHashCode();
        }
    }
