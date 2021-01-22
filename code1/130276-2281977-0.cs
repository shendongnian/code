    public class MyComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if ((a < 0) && (b >= 0))
            {
                return 1;
            }
            if ((a >= 0) && (b < 0))
            {
                return -1;
            }
            return int.Compare(a, b);
        }
    }
