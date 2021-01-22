    public static IEnumerable<T> Remove<T>(this IEnumerable<T> items, Func<T, bool> match)
        {
            var list = items.ToList();
            for (int idx = 0; idx < list.Count(); idx++)
            {
                if (match(list[idx]))
                {
                    list.RemoveAt(idx);
                }
            }
            return list.AsEnumerable();
        }
