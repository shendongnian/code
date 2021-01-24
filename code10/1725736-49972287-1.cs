    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Extension method that searches a list of generic objects' string properties 
        /// for the given search term using the 'Contains' object extension
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static IEnumerable<T> Search<T>(this IEnumerable<T> items, string search)
        {
            if (!string.IsNullOrEmpty(search))
                items = items.Where(i => i.Contains(search));
            return items;
        }
    }
