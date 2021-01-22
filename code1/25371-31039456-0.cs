        /// <summary>
        /// Changes all elements of IEnumerable by the change function
        /// </summary>
        /// <param name="enumerable">The enumerable where you want to change stuff</param>
        /// <param name="changeFunc">The way you want to change the stuff</param>
        /// <returns>An IEnumerable with all changes applied</returns>
        public static IEnumerable<T> Change<T>(this IEnumerable<T> enumerable, Func<T, T> changeFunc  )
        {
            foreach (var item in enumerable)
            {
                  yield return changeFunc.Invoke(item);
            }
        }
        /// <summary>
        /// Changes all elements of IEnumerable by the change function, that fullfill the where function
        /// </summary>
        /// <param name="enumerable">The enumerable where you want to change stuff</param>
        /// <param name="changeFunc">The way you want to change the stuff</param>
        /// <param name="whereFunc">The function to check where changes should be made</param>
        /// <returns>
        /// An IEnumerable with all changes applied
        /// </returns>
        public static IEnumerable<T> ChangeWhere<T>(this IEnumerable<T> enumerable, 
                                                    Func<T, T> changeFunc,
                                                    Func<T, bool> whereFunc)
        {
            foreach (var item in enumerable)
            {
                if (whereFunc.Invoke(item))
                {
                    yield return changeFunc.Invoke(item);
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
        /// <param name="changeFunc">The way you want to change the stuff</param>
        /// <param name="exceptFunc">The function to check where changes should not be made</param>
        /// <returns>
        /// An IEnumerable with all changes applied
        /// </returns>
        public static IEnumerable<T> ChangeExcept<T>(this IEnumerable<T> enumerable,
                                                     Func<T, T> changeFunc,
                                                     Func<T, bool> exceptFunc)
        {
            foreach (var item in enumerable)
            {
                if (!exceptFunc.Invoke(item))
                {
                    yield return changeFunc.Invoke(item);
                }
                else
                {
                    yield return item;
                }
            }
        }
