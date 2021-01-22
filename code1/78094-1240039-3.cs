        public static IEnumerable<Range<T>> MergeAdjacent<T>(this IEnumerable<Range<T>> source, Func<T, T, bool> isAdjacent)
        {
            using (var it = source.GetEnumerator())
            {
                if (!it.MoveNext())
                    yield break;
                var item = it.Current;
                while (it.MoveNext())
                    if (isAdjacent(item.End, it.Current.Start))
                    {
                        item = Range.Create(item.Start, it.Current.End);
                    }
                    else
                    {
                        yield return item;
                        item = it.Current;
                    }
                yield return item;
            }
        }
---
        static void Main(string[] args)
        {
            var ranges = new List<Range<int>>
            {
                Range.Create(1,3), Range.Create(4,5), Range.Create(7,10), 
                Range.Create(11,17), Range.Create(20,32), Range.Create(33,80), 
                Range.Create(90,100), 
            };
            foreach (var range in ranges.MergeAdjacent((r1, r2) => r1 + 1 == r2))
                Console.WriteLine(range);
        }
        // Result: 1-5, 7-20, 25-80, 90-100
