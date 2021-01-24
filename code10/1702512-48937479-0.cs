    public static partial class JTokenExtensions
    {
        /// <summary>
        /// Removes all the elements whose values, as defined by `selector`, belong to the collection of incoming values
        /// </summary>
        public static void RemoveAll<T>(this JArray array, IEnumerable<T> values, Func<JToken, T> selector, IEqualityComparer<T> comparer = null)
        {
            if (array == null || values == null || selector == null)
                throw new ArgumentNullException();
            var set = new HashSet<T>(values, comparer);
            array.RemoveAll(i => set.Contains(selector(i)));
        }
        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        public static void RemoveAll(this JArray array, Predicate<JToken> match)
        {
            if (array == null || match == null)
                throw new ArgumentNullException();
            array.ReplaceAll(array.Where(i => !match(i)).ToList());
        }
    }
