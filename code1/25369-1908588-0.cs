        /// <summary>
        /// Executes an Update statement block on all elements in an  IEnumerable of T
        /// sequence.
        /// </summary>
        /// <typeparam name="TSource">The source element type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="action">The action method to execute for each element.</param>
        /// <returns>The number of records affected.</returns>
        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            if (typeof (TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");
            var count = 0;
            foreach (var element in source)
            {
                action(element);
                count++;
            }
            return count;
        }
