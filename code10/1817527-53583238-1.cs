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
                if (usedEnumerator == null)
                    // An attempt has been made to enumerate usedEnumerator more than once; 
                    // throw an exception since this is not allowed.
                    throw new InvalidOperationException();
                yield return usedEnumerator.Current;
                while (usedEnumerator.MoveNext())
                {
                    yield return usedEnumerator.Current;
                }
                usedEnumerator = null;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
