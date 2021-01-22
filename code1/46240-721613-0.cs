    public class CountComparer : IComparer<List<string>>
    {
        #region IComparer<List<string>> Members
        public int Compare( List<string> x, List<string> y )
        {
            return x.Count.CompareTo( y.Count );
        }
        #endregion
    }
    
    oldList.Sort( new CountComparer() );
