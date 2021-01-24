     public struct Interval<T>
           where T : IComparable
    {
        public T Start { get; set; }
        public T End { get; set; }
		public T Visit { get; set; }
        public Interval(T visit, T start, T end)
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
