    public class RegionComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // TODO: Error handling, etc...
            return ((Region)x).RegNombre.CompareTo(((Region)y).RegNombre);
        }
    }
