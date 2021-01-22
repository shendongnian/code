        public static IEnumerable<IEnumerable<T>> GetSequences<T>
          (this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool flag = false;
            int id = 0;
            return source.GroupBy(x =>
                {
                    bool match = predicate(x);
                    if (match != flag)
                    {
                        id += 1;
                        flag = match;
                    }
                    return new { keep = match, id = id };
                })
                .Where(g => g.Key.keep)
                .Select(g => g.AsEnumerable());
        }
