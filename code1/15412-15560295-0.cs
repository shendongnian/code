    public static class EnumerableExtensions
    {
        // set up the regex parser once and for all
        private static readonly Regex Regex = new Regex(@"\d+|\D+", RegexOptions.Compiled | RegexOptions.Singleline);
        // stateless comparer can be built once
        private static readonly AggregateComparer Comparer = new AggregateComparer();
        public static IEnumerable<T> OrderByNatural<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            // first extract string from object using selector
            // then extract digit and non-digit groups
            Func<T, IEnumerable<IComparable>> splitter =
                s => Regex.Matches(selector(s))
                          .Cast<Match>()
                          .Select(m => Char.IsDigit(m.Value[0]) ? (IComparable) int.Parse(m.Value) : m.Value);
            return source.OrderBy(splitter, Comparer);
        }
        /// <summary>
        /// This comparer will compare two lists of objects against each other
        /// </summary>
        /// <remarks>Objects in each list are compare to their corresponding elements in the other
        /// list until a difference is found.</remarks>
        private class AggregateComparer : IComparer<IEnumerable<IComparable>>
        {
            public int Compare(IEnumerable<IComparable> x, IEnumerable<IComparable> y)
            {
                return
                    x.Zip(y, (a, b) => new {a, b})              // walk both lists
                     .Select(pair => pair.a.CompareTo(pair.b))  // compare each object
                     .FirstOrDefault(result => result != 0);    // until a difference is found
            }
        }
    }
