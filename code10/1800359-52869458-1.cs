    public class EmptyLastComparer: Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            if (String.IsNullOrWhiteSpace(x) && !String.IsNullOrWhiteSpace(y))
            {
                return 1;
            }
            else if (String.IsNullOrWhiteSpace(x) && String.IsNullOrWhiteSpace(y))
            {
                return 0;
            }
            else if (!String.IsNullOrWhiteSpace(x) && String.IsNullOrWhiteSpace(y))
            {
                return -1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
