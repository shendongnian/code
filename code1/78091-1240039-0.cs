        public static IEnumerable<Range<T>> MergeAdjacent<T>(this IEnumerable<Range<T>> source, Func<T, T, bool> isAdjacent)
        {
            using (var it = source.GetEnumerator())
            {
                if (it.MoveNext())
                {
                    Range<T> carry = it.Current;
                    while (it.MoveNext())
                    {
                        Range<T> current = it.Current;
                        if (isAdjacent(carry.End, current.Start))
                        {
                            carry = new Range<T> { Start = carry.Start, End = current.End };
                        }
                        else
                        {
                            Range<T> res = carry;
                            carry = current;
                            yield return res;
                        }
                    }
                    yield return carry;
                }
                else
                    yield break;
            }
        }
