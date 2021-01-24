    public delegate bool RichPredicate<T>(T item, int originalIndex, int countedIndex, bool hasMoreItems);
    public static class EnumerableExtensions
    {
        /// <remarks>
        /// This was contributed by Aly El-Haddad as an answer to this Stackoverflow.com question:
        /// https://stackoverflow.com/q/54829095/3602352
        /// </remarks>
        public static IEnumerable<T> RichWhere<T>(this IEnumerable<T> source, RichPredicate<T> predicate)
        {
            return new RichWhereIterator<T>(source, predicate);
        }
        private class RichWhereIterator<T> : IEnumerable<T>, IEnumerator<T>
        {
            private readonly int threadId;
            private readonly IEnumerable<T> source;
            private readonly RichPredicate<T> predicate;
            private IEnumerator<T> enumerator;
            private int state;
            private int countedIndex = -1;
            private int originalIndex = -1;
            private bool hasMoreItems;
            public RichWhereIterator(IEnumerable<T> source, RichPredicate<T> predicate)
            {
                threadId = Thread.CurrentThread.ManagedThreadId;
                this.source = source ?? throw new ArgumentNullException(nameof(source));
                this.predicate = predicate ?? ((item, originalIndex, countedIndex, hasMoreItems) => true);
            }
            public T Current { get; private set; }
            object IEnumerator.Current => Current;
            public void Dispose()
            {
                if (enumerator is IDisposable disposable)
                    disposable.Dispose();
                enumerator = null;
                originalIndex = -1;
                countedIndex = -1;
                hasMoreItems = false;
                Current = default(T);
                state = -1;
            }
            public bool MoveNext()
            {
                switch (state)
                {
                    case 1:
                        enumerator = source.GetEnumerator();
                        if (!(hasMoreItems = enumerator.MoveNext()))
                        {
                            Dispose();
                            break;
                        }
                        ++originalIndex;
                        state = 2;
                        goto case 2;
                    case 2:
                        if (!hasMoreItems) //last predicate returned true and that was the last item
                        {
                            Dispose();
                            break;
                        }
                        T current = enumerator.Current;
                        hasMoreItems = enumerator.MoveNext();
                        ++originalIndex;
                        if (predicate(current, originalIndex - 1, countedIndex + 1, hasMoreItems))
                        {
                            ++countedIndex;
                            Current = current;
                            return true;
                        }
                        else if (hasMoreItems)
                        { goto case 2; }
                        //predicate returned false and there're no more items
                        Dispose();
                        break;
                }
                return false;
            }
            public void Reset()
            {
                Current = default(T);
                hasMoreItems = false;
                originalIndex = -1;
                countedIndex = -1;
                state = 1;
            }
            public IEnumerator<T> GetEnumerator()
            {
                if (threadId == Thread.CurrentThread.ManagedThreadId && state == 0)
                {
                    state = 1;
                    return this;
                }
                return new RichWhereIterator<T>(source, predicate) { state = 1 };
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
