        public static IEnumerable<T> TakeLast<T>(this IList<T> list, int count)
        {
            count = Math.Min(count, list.Count);
            for (int i = list.Count - count; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
