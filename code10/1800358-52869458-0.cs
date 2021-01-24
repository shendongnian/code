    public class EmptyLastComparer: Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            if (String.IsNullOrWhiteSpace(x) && !String.IsNullOrWhiteSpace(y))
            {
                return 1;
            }
            return x.CompareTo(y);
        }
    }
