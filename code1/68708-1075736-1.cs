        public class MyStringComparer : IComparer<string>
        {
            #region IComparer<string> Members
            public int Compare(string x, string y)
            {
                if (x[0] == y[0])
                {
                    return x.Length.CompareTo(y.Length);
                }
                else return x[0].CompareTo(y[0]);
            }
            #endregion
        }
