    public static partial class EnumerableExtensions
    {
        public static bool IfNonEmpty<T>(this IEnumerable<T> source, Action<IEnumerable<T>> func)
        {
            if (source == null|| func == null)
                throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return false;
                func(new UsedEnumerator<T>(enumerator));
                return true;
            }
        }
        class UsedEnumerator<T> : IEnumerable<T>
        {
            IEnumerator<T> usedEnumerator;
            public UsedEnumerator(IEnumerator<T> usedEnumerator)
            {
                if (usedEnumerator == null)
                    throw new ArgumentNullException();
                this.usedEnumerator = usedEnumerator;
            }
            public IEnumerator<T> GetEnumerator()
            {
                var localEnumerator = System.Threading.Interlocked.Exchange(ref usedEnumerator, null);
                if (localEnumerator == null)
                    // An attempt has been made to enumerate usedEnumerator more than once; 
                    // throw an exception since this is not allowed.
                    throw new InvalidOperationException();
                yield return localEnumerator.Current;
                while (localEnumerator.MoveNext())
                {
                    yield return localEnumerator.Current;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
