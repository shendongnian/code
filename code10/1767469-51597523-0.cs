    public class AppleComparer : IComparer<string>, IComparer<object>
    {
        public int Compare(string x, string y)
        {
            if (x.Contains("APPLE") & y.Contains("APPLE")) {
                return x.Substring("APPLE".Length).CompareTo(y.Substring("APPLE".Length));
            }
            else if (x.Contains("APPLE") & !y.Contains("APPLE")) {
                return 1;
            }
            else if (!x.Contains("APPLE") & y.Contains("APPLE")) {
                return -1;
            }
            else { return x.CompareTo(y); }
        }
        public int Compare(object x, object y)
        {
            return Compare(x.ToString(), y.ToString());
        }
    }
