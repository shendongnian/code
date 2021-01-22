        public static IEnumerable<int> QSort2(IEnumerable<int> source)
        {
            if (!source.Any())
                return source;
            int first = source.First();
            return source
                .GroupBy(i => i.CompareTo(first))
                .OrderBy(g => g.Key)
                .SelectMany(g => g.Key == 0 ? g : QSort2(g));
        }
