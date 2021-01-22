        /// <summary>
        /// Changes all elements of IEnumerable by the change function
        /// </summary>
        /// <param name="enumerable">The enumerable where you want to change stuff</param>
        /// <param name="change">The way you want to change the stuff</param>
        /// <returns>An IEnumerable with all changes applied</returns>
        public static IEnumerable<T> Change<T>(this IEnumerable<T> enumerable, Func<T, T> change  )
        {
            foreach (var item in enumerable)
            {
                yield return change(item);
            }
        }
        /// <summary>
        /// Changes all elements of IEnumerable by the change function, that fullfill the where function
        /// </summary>
        /// <param name="enumerable">The enumerable where you want to change stuff</param>
        /// <param name="change">The way you want to change the stuff</param>
        /// <param name="where">The function to check where changes should be made</param>
        /// <returns>
        /// An IEnumerable with all changes applied
        /// </returns>
        public static IEnumerable<T> ChangeWhere<T>(this IEnumerable<T> enumerable, 
                                                    Func<T, T> change,
                                                    Func<T, bool> @where)
        {
            foreach (var item in enumerable)
            {
                if (@where(item))
                {
                    yield return change(item);
                }
                else
                {
                    yield return item;
                }
            }
        }
        /// <summary>
        /// Changes all elements of IEnumerable by the change function that do not fullfill the except function
        /// </summary>
        /// <param name="enumerable">The enumerable where you want to change stuff</param>
        /// <param name="change">The way you want to change the stuff</param>
        /// <param name="where">The function to check where changes should not be made</param>
        /// <returns>
        /// An IEnumerable with all changes applied
        /// </returns>
        public static IEnumerable<T> ChangeExcept<T>(this IEnumerable<T> enumerable,
                                                     Func<T, T> change,
                                                     Func<T, bool> @where)
        {
            foreach (var item in enumerable)
            {
                if (!@where(item))
                {
                    yield return change(item);
                }
                else
                {
                    yield return item;
                }
            }
        }
