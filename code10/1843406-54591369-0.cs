    public class ApprovedComparer : IComparer<bool?>
    {
        public int Compare(bool? x, bool? y)
        {
            var a = 0;
            var b = 0;
            if (x.HasValue)
                 a = x.Value ? 2 : 1;
            if (y.HasValue)
                a = y.Value ? 2 : 1;
            return a - b;
        }
    }
