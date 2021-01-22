     /// <summary>
        /// Checks for an empty collection, and sends the value set in the default constructor for the desired field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static TResult MinGuarded<T, TResult>(this IEnumerable<T> items, Func<T, TResult> expression) where T : new() {
          if(items.IsEmpty()) {
            return (new List<T> { new T() }).Min(expression);
          }
          return items.Min(expression);
        }
    
        /// <summary>
        /// Checks for an empty collection, and sends the value set in the default constructor for the desired field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static TResult MaxGuarded<T, TResult>(this IEnumerable<T> items, Func<T, TResult> expression) where T : new() {
          if(items.IsEmpty()) {
            return (new List<T> { new T() }).Max(expression);
          }
          return items.Max(expression);
        }
