        /// <summary>
        /// This method returns items in a set that are not in 
        /// another set of a different type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOther"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items"></param>
        /// <param name="other"></param>
        /// <param name="getItemKey"></param>
        /// <param name="getOtherKey"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T, TOther, TKey>(
                                               this IEnumerable<T> items,
                                               IEnumerable<TOther> other,
                                               Func<T, TKey> getItemKey,
                                               Func<TOther, TKey> getOtherKey)
        {
            return from item in items
                   join otherItem in other on getItemKey(item)
                   equals getOtherKey(otherItem) into tempItems
                   from temp in tempItems.DefaultIfEmpty()
                   where ReferenceEquals(null, temp) || temp.Equals(default(TOther))
                   select item;
        }
