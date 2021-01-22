    public static class ListExtensions
    {
        public static int RemoveAll<T>(this List<T> list, Predicate<T> match)
        {
            if (list == null)
                throw new NullReferenceException();
            if (match == null)
                throw new ArgumentNullException("match");
            int i = 0;
            int j = 0;
            for (i = 0; i < list.Count; i++)
            {
                if (!match(list[i]))
                {
                    if (i != j)
                        list[j] = list[i];
                    j++;
                }
            }
            int removed = i - j;
            if (removed > 0)
                list.RemoveRange(list.Count - removed, removed);
            return removed;
        }
    }
