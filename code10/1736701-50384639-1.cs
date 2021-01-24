    public static class ObservableBuilder {
        public static IObservable<T> Repeat<T>(this Func<Task<T>> taskFactory, TimeSpan delay = default(TimeSpan),
            Func<Exception, bool> onError = null) {
            var ienum = typeof(T).GetInterfaces().FirstOrDefault(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (ienum != null) {
                // implements IEnumerable - create instance of comparer and use
                var comparer = (IEqualityComparer<T>) Activator.CreateInstance(typeof(EnumerableComparer<,>).MakeGenericType(typeof(T), ienum.GenericTypeArguments[0]));
                return new TaskRepeatObservable<T>(taskFactory, delay, onError).DistinctUntilChanged(comparer);
            }
            // otherwise - don't use
            return new TaskRepeatObservable<T>(taskFactory, delay, onError).DistinctUntilChanged();
        }
        private class EnumerableComparer<T, TItem> : IEqualityComparer<T> where T : IEnumerable<TItem> {
            public bool Equals(T x, T y) {
                return ReferenceEquals(x, y) || x != null && y != null && x.SequenceEqual(y);
            }
            public int GetHashCode(T obj) {
                // Will not throw an OverflowException
                unchecked {
                    return obj.Where(e => e != null).Select(e => e.GetHashCode()).Aggregate(17, (a, b) => 23 * a + b);
                }
            }
        }
    }  
