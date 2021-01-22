        public static IEnumerable<int> RandomNumberGenerator()
        {
            while(true) yield return random.Next();
        }
        public static IEnumerable<IEnumerable<int>> Slice(this IEnumerable<int> enumerable, int size, int count)
        {
            var slices = new List<List<int>>();
            foreach (var iteration in Enumerable.Range(0, count)){
                var list = new List<int>();
                list.AddRange(enumerable.Take(size));
                slices.Add(list);
            }
            return slices;
        }
