    class DateTimeAscendingComparer : IComparer<DateTime>
    {
        public int Compare(DateTime a, DateTime b)
        {
            return a.CompareTo(b);
        }
    }
