    public struct Range
    {
        public Range(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
        public int From { get; }
        public int To { get; }
        public static implicit operator Range(int v)
        {
            return new Range(v, v);
        }
    }
