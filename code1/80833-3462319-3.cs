        /// <summary>
    /// Extensions for <see cref="System.Collections.Generic.IEnumerable"/>.
    /// </summary>
    public static class IEnumerableOfTExtensions
    {
        /// <summary>
        /// Performs the <see cref="System.Action"/>
        /// on each item in the enumerable object.
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// “I am philosophically opposed to providing such a method, for two reasons.
        /// …The first reason is that doing so violates the functional programming principles
        /// that all the other sequence operators are based upon. Clearly the sole purpose of a call
        /// to this method is to cause side effects.”
        /// —Eric Lippert, “foreach” vs “ForEach” [http://blogs.msdn.com/b/ericlippert/archive/2009/05/18/foreach-vs-foreach.aspx]
        /// </remarks>
        public static void ForEachInEnumerable<TEnumerable>(this IEnumerable<TEnumerable> enumerable, Action<TEnumerable> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
