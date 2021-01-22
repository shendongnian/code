    using System.Collections.Generic;
    using System.Linq;
    using System;
    static class Range
    {
        public static Range<T> Create<T>(T start, T end)
        {
            return new Range<T>(start, end);
        }
        public static IEnumerable<Range<T>> Normalize<T>(
            this IEnumerable<Range<T>> ranges)
        {
            return Normalize<T>(ranges, null);
        }
        public static IEnumerable<Range<T>> Normalize<T>(
            this IEnumerable<Range<T>> ranges, IComparer<T> comparer)
        {
            var list = ranges.ToList();
            if (comparer == null) comparer = Comparer<T>.Default;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                for (int j = 0; j < i; j++)
                {
                    Range<T>? newValue = TryMerge<T>(comparer, item, list[j]);
                    // did we find a useful transformation?
                    if (newValue != null)
                    {
                        list[j] = newValue.GetValueOrDefault();
                        list.RemoveAt(i);
                        break;
                    }
                }
            }
            list.Sort((x, y) =>
            {
                int t = comparer.Compare(x.Start, y.Start);
                if (t == 0) t = comparer.Compare(x.End, y.End);
                return t;
            });
            return list.AsEnumerable();
        }
        private static Range<T>? TryMerge<T>(IComparer<T> comparer, Range<T> item, Range<T> other)
        {
            if (comparer.Compare(other.End, item.Start) == 0)
            { // adjacent ranges
                return new Range<T>(other.Start, item.End);
            }
            if (comparer.Compare(item.End, other.Start) == 0)
            { // adjacent ranges
                return new Range<T>(item.Start, other.End);
            }
            if (comparer.Compare(item.Start, other.Start) <= 0
                && comparer.Compare(item.End, other.End) >= 0)
            { // item fully swalls other
                return item;
            }
            if (comparer.Compare(other.Start, item.Start) <= 0
                && comparer.Compare(other.End, item.End) >= 0)
            { // other fully swallows item
                return other;
            }
            if (comparer.Compare(item.Start, other.Start) <= 0
                && comparer.Compare(item.End, other.Start) >= 0
                && comparer.Compare(item.End, other.End) <= 0)
            { // partial overlap
                return new Range<T>(item.Start, other.End);
            }
            if (comparer.Compare(other.Start, item.Start) <= 0
                 && comparer.Compare(other.End, item.Start) >= 0
                && comparer.Compare(other.End, item.End) <= 0)
            { // partial overlap
                return new Range<T>(other.Start, item.End);
            }
            return null;
        }
    }
    public struct Range<T>
    {
        private readonly T start, end;
        public T Start { get { return start; } }
        public T End { get { return end; } }
        public Range(T start, T end)
        {
            this.start = start;
            this.end = end;
        }
        public override string ToString()
        {
            return start + " to " + end;
        }
    }
    static class Program
    {
        static void Main()
        {
            var data = new[] 
            {
                Range.Create(1,5), Range.Create(3,9),
                Range.Create(11,15), Range.Create(12,14),
                Range.Create(13,20)
            };
            var result = data.Normalize();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
