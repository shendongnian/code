        public static IEnumerable<T> WhereIndexes<T>(this IEnumerable<T> collection, IEnumerable<int> indexes)
        {
            IList<T> l = new List<T>(collection);
            foreach (var index in indexes)
            {
                yield return l[index]; 
            }
        }
