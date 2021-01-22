        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> elements, int countToTake)
        {
            var random = new Random();
            var internalList = elements.ToList();
            
            var selected = new List<T>();
            for (var i = 0; i < countToTake; ++i)
            {
                var next = random.Next(0, internalList.Count - selected.Count);
                selected.Add(internalList[next]);
                internalList[next] = internalList[internalList.Count - selected.Count];
            }
            return selected;
        }
