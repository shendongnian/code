    static class RepeatedExtension
    {
        public static IEnumerable<T> Repeated<T>(this IEnumerable<T> source)
        {
            var distinct = new Dictionary<T, int>();
            foreach (var item in source)
            {
                if (!distinct.ContainsKey(item))
                    distinct.Add(item, 1);
                else
                {
                    if (distinct[item]++ == 1) // only yield items on first repeated occurence
                        yield return item;
                }                    
            }
        }
    }
