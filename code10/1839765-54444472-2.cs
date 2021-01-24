    public class Interval<T> where T : struct, IComparable
    {
        public T? Start { get; set; }
        public T? End { get; set; }
		public int Visit { get; set; }
    public Interval(int visit, T? start, T? end)
    {
			Visit = visit;
      Start = start;
      End = end;
    }
    public bool InRange(T value)
    {
      return ((!Start.HasValue || value.CompareTo(Start.Value) > 0) &&
              (!End.HasValue || End.Value.CompareTo(value) >= 0));
    }
    }
