        public IDictionary<int, T> GetRange<T>(
            IDictionary<int, T> source, int min, int max)
        {
            // add error checking for min,max, null, etc...
            int capacity = Math.Max(0, max - min);
            Dictionary<int, T> target = new Dictionary<int, T>(capacity);
            for (int key = min; key < max; key++)
            {
                if (source.ContainsKey(key))
                {
                    target.Add(key, source[key]);
                }
            }
            return target;
        }
