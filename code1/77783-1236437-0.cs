    [DebuggerDisplay("Range {Start} - {End}")]
    public class Range<T> where T:struct
    {
        public T Start { set; get; }
        public T End { set; get; }
        public bool Overlap(Range<T> other) {
            return (Within(other.Start) || Within(other.End) || other.Within(this.Start) || other.Within(this.End)) ;
        }
        public bool Within(T point)
        {
            var Comp = Comparer<T>.Default;
            var st = Comp.Compare(point, this.Start);
            var ed = Comp.Compare(this.End, point);
            return (st >= 0 && ed >= 0);
        }
        public void Combine(Range<T> other) {
            var Comp = Comparer<T>.Default;
            if (Comp.Compare(this.Start, other.Start) > 0 ) this.Start = other.Start;
            if (Comp.Compare(other.End, this.End) > 0) this.End = other.End;
        }
    }
    class RangeMerge
    {
        public static List<Range<T>> Collapse<T>(List<Range<T>> r) where T:struct
        {
            var result = new List<Range<T>>();
            var sorted = r.OrderBy(t => t.Start);
            do {
                var first = sorted.FirstOrDefault();
                var other = sorted.Skip(1).FirstOrDefault(x => x.Overlap(first));
                if (other != null) {
                    //combines in-place
                    first.Combine(other);
                    r.Remove(other);
                } else {
                    result.Add(first);
                    r.Remove(first);
                }
            } while (r.Count > 0);
            return result;
        }
    }
