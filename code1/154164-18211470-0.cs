    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs lexical comparison of 2 IEnumerable collections holding elements of type T. 
        /// </summary>
        /// <typeparam name="T">Type of collection elements.</typeparam>
        /// <param name="first">The first collection to compare.</param>
        /// <param name="second">The second collection to compare.</param>
        /// <returns>A signed integer that indicates the relative values of a and b:
        /// Less than zero: first is less than second;
        /// Zero: first is equal to second;
        /// Greater than zero: first is greater than second.
        /// </returns>
        /// <remarks>
        /// Can be called as either static method: EnumerableExtensions.Compare(a, b) or
        /// extension method: a.Compare(b).
        /// </remarks>
        public static int Compare<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            // If one of collection objects is null, use the default Comparer class
            // (null is considered to be less than any other object)
            if (first == null || second == null)
                return Comparer.Default.Compare(first, second);
            var elementComparer = Comparer<T>.Default;
            int compareResult;
            using (var firstEnum = first.GetEnumerator())
            using (var secondEnum = second.GetEnumerator())
            {
                do
                {
                    bool gotFirst = firstEnum.MoveNext();
                    bool gotSecond = secondEnum.MoveNext();
                    // Reached the end of collections => assume equal
                    if (!gotFirst && !gotSecond)
                        return 0;
                    // Different sizes => treat collection of larger size as "greater"
                    if (gotFirst != gotSecond)
                        return gotFirst ? 1 : -1;
                    compareResult = elementComparer.Compare(firstEnum.Current, secondEnum.Current);
                } while (compareResult == 0);
            }
            return compareResult;
        }
    }
