        public static IEnumerable<T> TakeLast<T>(
               this IEnumerable<T> source, int count)
        {
            IList<T> list = (source as IList<T>) ?? source.ToList();
            count = Math.Min(count, list.Count);
            for (int i = list.Count - count; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
