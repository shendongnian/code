    employeeList.ForEach(e => Save(e));
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Executes an <see cref="Action&lt;T&gt;"/> on each item in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable&lt;T&gt;"/> in which each item should be processed.</param>
        /// <param name="action">The <see cref="Action&lt;T&gt;"/> to be performed on each item in the sequence.</param>
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> action
            )
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");
            foreach (T item in source)
                action(item);
        }
    }
