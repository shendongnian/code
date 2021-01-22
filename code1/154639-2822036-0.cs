    public class ItemWithPrevious<T>
    {
        public T Previous;
        public T Current;
    }
    public static class MyExtensions
    {
        public static IObservable<ItemWithPrevious<T>> CombineWithPrevious<T>(this IObservable<T> source)
        {
            var previous = default(T);
            return source
                .Select(t => new ItemWithPrevious<T> { Previous = previous, Current = t })
                .Do(items => previous = items.Current);
        }
    }
