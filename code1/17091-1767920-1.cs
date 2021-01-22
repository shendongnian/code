    internal static class SortingHelpers
    {
        /// <summary>
        /// Performs an insertion sort on this list.
        /// </summary>
        /// <typeparam name="T">The type of the list supplied.</typeparam>
        /// <param name="list">the list to sort.</param>
        /// <param name="comparison">the method for comparison of two elements.</param>
        /// <returns></returns>
        public static void InsertionSort<T>(this IList<T> list, Func<T, T, bool> comparison)
        {
            for (int i = 2; i < list.Count; i++)
            {
                for (int j = i; j > 1 && comparison(list[j], list[j - 1]); j--)
                {
                    T tempItem = list[j];
                    list.RemoveAt(j);
                    list.Insert(j - 1, tempItem);
                }
            }
        }
    }
