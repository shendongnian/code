    public static class CollapseRange
    {
        public static IEnumerable<Range<T>> Collapse<T>(this IEnumerable<Range<T>> me)
            where T:struct
        {
            var result = new List<Range<T>>();
            var sorted = me.OrderBy(x => x.Start).ToList();
            do {
                var first = sorted.FirstOrDefault();
                sorted.Remove(first);
                while (sorted.Any(x => x.Overlap(first))) {
                    var other = sorted.FirstOrDefault(x => x.Overlap(first));
                    first = first.Combine(other);
                    sorted.Remove(other);
                }
                result.Add(first);
            } while (sorted.Count > 0);
            return result;
        }
    }
    [DebuggerDisplay("Range {Start} - {End}")]
    public class Range<T> where T : struct
    {
        public T Start { set; get; }
        public T End { set; get; }
        public bool Overlap(Range<T> other)
        {
            return (Within(other.Start) || Within(other.End) || other.Within(this.Start) || other.Within(this.End));
        }
        public bool Within(T point)
        {
            var Comp = Comparer<T>.Default;
            var st = Comp.Compare(point, this.Start);
            var ed = Comp.Compare(this.End, point);
            return (st >= 0 && ed >= 0);
        }
        /// <summary>Combines to ranges, updating the current range</summary>
        public void Merge(Range<T> other)
        {
            var Comp = Comparer<T>.Default;
            if (Comp.Compare(this.Start, other.Start) > 0) this.Start = other.Start;
            if (Comp.Compare(other.End, this.End) > 0) this.End = other.End;
        }
        /// <summary>Combines to ranges, returning a new range in their place</summary>
        public Range<T> Combine(Range<T> other)
        {
            var Comp = Comparer<T>.Default;
            var newRange = new Range<T>() { Start = this.Start, End = this.End };
            newRange.Start = (Comp.Compare(this.Start, other.Start) > 0) ? other.Start : this.Start;
            newRange.End = (Comp.Compare(other.End, this.End) > 0) ? other.End : this.End;
            return newRange;
        }
    }
