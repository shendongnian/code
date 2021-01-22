    /// <summary>
        /// Returns a list with the ability to specify key(s) to compare uniqueness on
        /// </summary>
        /// <typeparam name="T">Source type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="keyPredicate">Predicate with key(s) to perform comparison on</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source,
                                                 Func<T, object> keyPredicate)
        {
            return source.Distinct(new GenericComparer<T>(keyPredicate));
        }
