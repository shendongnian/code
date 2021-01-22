    class Range<T> where T: IComparable<T>
    {
        public T From { get; set; }
        public T To { get; set; }
        public Range(T from, T to) { this.From = from; this.To = to; }
        public IEnumerable<T> Enumerate(Func<T, T> next)
        {
            for (T t = this.From; t.CompareTo(this.To) < 0; t = next(t))
            {
                yield return t;
            }
        }
        static void Example()
        {
            new Range<int> (0, 100).Enumerate(i => i+1)
        }
    }
