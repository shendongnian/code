    public static class DataFileExtensions
    {
        public static Dictionary<string, int[]> ParseDataFile(string fileName)
        {
            var separators = new [] { ' ' };
            var query = from pair in File.ReadLines(fileName).Chunk(2)
                        let key = pair[0].TrimEnd(';')
                        let value = (pair.Count < 2 ? "" : pair[1]).Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s, NumberFormatInfo.InvariantInfo)).ToArray()
                        select new { key, value };
            return query.ToDictionary(p => p.key, p => p.value);
        }
    }
    public static class EnumerableExtensions
    {
        // Adapted from the answer to "Split List into Sublists with LINQ" by casperOne
        // https://stackoverflow.com/questions/419019/split-list-into-sublists-with-linq/
        // https://stackoverflow.com/a/419058
        // https://stackoverflow.com/users/50776/casperone
        public static IEnumerable<List<T>> Chunk<T>(this IEnumerable<T> enumerable, int groupSize)
        {
            // The list to return.
            List<T> list = new List<T>(groupSize);
            // Cycle through all of the items.
            foreach (T item in enumerable)
            {
                // Add the item.
                list.Add(item);
                // If the list has the number of elements, return that.
                if (list.Count == groupSize)
                {
                    // Return the list.
                    yield return list;
                    // Set the list to a new list.
                    list = new List<T>(groupSize);
                }
            }
            // Return the remainder if there is any,
            if (list.Count != 0)
            {
                // Return the list.
                yield return list;
            }
        }
    }
