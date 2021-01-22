    public class MyOwnComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.StarsWith("_") && !y.StartsWith("_"))
                return 1;
            else if (!x.StartsWith("_") && y.StartsWith("_"))
                return -1;
            else
                return x.CompareTo(y);
        }
    }
