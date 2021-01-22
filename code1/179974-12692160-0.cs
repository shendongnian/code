    public class DegreeComparer : IComparer<int>
    {
        #region IComparer<int> Members
        public int Compare(int x, int y)
        {
            if (x < y)
                return -1;
            else
                return 1;
        }
        #endregion
    }
