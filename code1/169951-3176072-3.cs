    public static class GroupingExtension
    {
        public static IEnumerable<IEnumerable<T>> Grouped<T>(
            this IEnumerable<T> input,
            int groupCount)
        {
            if (input == null) throw new ArgumentException("input");
            if (groupCount < 1) throw new ArgumentException("groupCount");
    
            IEnumerator<T> e = input.GetEnumerator();
    
            while (true)
            {
                List<T> l = new List<T>();
                for (int n = 0; n < groupCount; ++n)
                {
                    if (!e.MoveNext())
                    {
                        if (n != 0)
                        {
                            yield return l;
                        }
                        yield break;
                    }
                    l.Add(e.Current);
                }
                yield return l;
            }
        }
    }
