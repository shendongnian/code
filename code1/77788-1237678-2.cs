        public static IEnumerable<Range<T>> Collapse<T>(this IEnumerable<Range<T>> ranges, IComparer<T> comparer)
        {
            if(ranges == null || !ranges.Any())
                yield break;
            if (comparer == null)
                comparer = Comparer<T>.Default;
            var orderdList = ranges.OrderBy(r => r.Start);
            var firstRange = orderdList.First();
            
            T min = firstRange.Start;
            T max = firstRange.End;
            foreach (var current in orderdList.Skip(1))
            {
                if (comparer.Compare(current.End, max) > 0 && comparer.Compare(current.Start, max) > 0)
                {
                    yield return Create(min, max);
                    min = current.Start;
                }
                max = comparer.Compare(max, current.End) > 0 ? max : current.End;
            }
            yield return Create(min, max);
        }
