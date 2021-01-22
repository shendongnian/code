        internal class ImpreciseCompareDate : IComparer<DateTime>
    {
        private readonly double _Tolerance;
        public ImpreciseCompareDate(double MillisecondsTolerance)
        {
            _Tolerance = MillisecondsTolerance;
        }
        public int Compare(DateTime x, DateTime y)
        {
            return Math.Abs((x - y).TotalMilliseconds) < _Tolerance ? 0 : x.CompareTo(y);
        }
    }
