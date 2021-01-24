    // Case Insensitive String HashSet, or CIStringSet for short.
    public class CIStringSet : HashSet<string>
    {
        public CIStringSet() : base(CIStringComparer.Instance)
        {
        }
    }
    // Case Insensitive String Comparer, or CIStringComparer for short.
    public class CIStringComparer : IEqualityComparer<string>
    {
        // No need to ever have multiple instances, so make it a Singleton
        public static CIStringComparer Instance = new CIStringComparer();
        private CIStringComparer()
        {
        }
        public bool Equals(string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);
        }
        public int GetHashCode(string s)
        {
            return s.GetHashCode();
        }
    }
