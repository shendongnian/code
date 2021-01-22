    public class TagComparer : IComparer<cTag>
    {
        public int Compare(cTag first, cTag second)
        {
            if (first != null && second != null)
            {
                // We can compare both properties.
                return first.date.CompareTo(second.date);
            }
            if (first == null && second == null)
            {
                // We can't compare any properties, so they are essentially equal.
                return 0;
            }
            if (first != null)
            {
                // Only the first instance is not null, so prefer that.
                return -1;
            }
            // Only the second instance is not null, so prefer that.
            return 1;
        }
    }
    
    var list = new List<cTag>();
    // populate list.
    
    list.Sort(new TagComparer());
    
