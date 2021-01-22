    namespace System.Linq
    {
        /// <summary>
        /// Class to hold extension methods to Linq.
        /// </summary>
        public static class LinqExtensions
        {
            /// <summary>
            /// Changes all elements of IEnumerable by the change function
            /// </summary>
            /// <param name="enumerable">The enumerable where you want to change stuff</param>
            /// <param name="change">The way you want to change the stuff</param>
            /// <returns>An IEnumerable with all changes applied</returns>
            public static IEnumerable<T> Change<T>(this IEnumerable<T> enumerable, Func<T, T> change  )
            {
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(change, "change");
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
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(change, "change");
                ArgumentCheck.IsNullorWhiteSpace(@where, "where");
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
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(change, "change");
                ArgumentCheck.IsNullorWhiteSpace(@where, "where");
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
            /// <summary>
            /// Update all elements of IEnumerable by the update function (only works with reference types)
            /// </summary>
            /// <param name="enumerable">The enumerable where you want to change stuff</param>
            /// <param name="update">The way you want to change the stuff</param>
            /// <returns>
            /// The same enumerable you passed in
            /// </returns>
            public static IEnumerable<T> Update<T>(this IEnumerable<T> enumerable,
                                                   Action<T> update) where T : class
            {
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(update, "update");
                foreach (var item in enumerable)
                {
                    update(item);
                }
                return enumerable;
            }
            /// <summary>
            /// Update all elements of IEnumerable by the update function (only works with reference types)
            /// where the where function returns true
            /// </summary>
            /// <param name="enumerable">The enumerable where you want to change stuff</param>
            /// <param name="update">The way you want to change the stuff</param>
            /// <param name="where">The function to check where updates should be made</param>
            /// <returns>
            /// The same enumerable you passed in
            /// </returns>
            public static IEnumerable<T> UpdateWhere<T>(this IEnumerable<T> enumerable,
                                                   Action<T> update, Func<T, bool> where) where T : class
            {
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(update, "update");
                foreach (var item in enumerable)
                {
                    if (where(item))
                    {
                        update(item);
                    }
                }
                return enumerable;
            }
            /// <summary>
            /// Update all elements of IEnumerable by the update function (only works with reference types)
            /// Except the elements from the where function
            /// </summary>
            /// <param name="enumerable">The enumerable where you want to change stuff</param>
            /// <param name="update">The way you want to change the stuff</param>
            /// <param name="where">The function to check where changes should not be made</param>
            /// <returns>
            /// The same enumerable you passed in
            /// </returns>
            public static IEnumerable<T> UpdateExcept<T>(this IEnumerable<T> enumerable,
                                                   Action<T> update, Func<T, bool> where) where T : class
            {
                ArgumentCheck.IsNullorWhiteSpace(enumerable, "enumerable");
                ArgumentCheck.IsNullorWhiteSpace(update, "update");
                foreach (var item in enumerable)
                {
                    if (!where(item))
                    {
                        update(item);
                    }
                }
                return enumerable;
            }
        }
    }
