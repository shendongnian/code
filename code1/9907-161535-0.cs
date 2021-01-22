    class Program
    {
        static void Main()
        {
            List<string> left = new List<string> { "Alice", "Charles", "Derek" };
            List<string> right = new List<string> { "Bob", "Charles", "Ernie" };
            EnumerableExtensions.CompareSortedCollections(left, right, StringComparer.CurrentCultureIgnoreCase,
                s => Console.WriteLine("Left: " + s), s => Console.WriteLine("Right: " + s), (x,y) => Console.WriteLine("Both: " + x + y));
        }
    }
    static class EnumerableExtensions
    {
        public static void CompareSortedCollections<T>(IEnumerable<T> source, IEnumerable<T> destination, IComparer<T> comparer, Action<T> onLeftOnly, Action<T> onRightOnly, Action<T, T> onBoth)
        {
            EnumerableIterator<T> sourceIterator = new EnumerableIterator<T>(source);
            EnumerableIterator<T> destinationIterator = new EnumerableIterator<T>(destination);
            while (sourceIterator.HasCurrent && destinationIterator.HasCurrent)
            {
                // While LHS < RHS, the items in LHS aren't in RHS
                while (sourceIterator.HasCurrent && (comparer.Compare(sourceIterator.Current, destinationIterator.Current) < 0))
                {
                    onLeftOnly(sourceIterator.Current);
                    sourceIterator.MoveNext();
                }
                // While RHS < LHS, the items in RHS aren't in LHS
                while (sourceIterator.HasCurrent && destinationIterator.HasCurrent && (comparer.Compare(sourceIterator.Current, destinationIterator.Current) > 0))
                {
                    onRightOnly(destinationIterator.Current);
                    destinationIterator.MoveNext();
                }
                // While LHS==RHS, the items are in both
                while (sourceIterator.HasCurrent && destinationIterator.HasCurrent && (comparer.Compare(sourceIterator.Current, destinationIterator.Current) == 0))
                {
                    onBoth(sourceIterator.Current, destinationIterator.Current);
                    sourceIterator.MoveNext();
                    destinationIterator.MoveNext();
                }
            }
            // Mop up.
            while (sourceIterator.HasCurrent)
            {
                onLeftOnly(sourceIterator.Current);
                sourceIterator.MoveNext();
            }
            while (destinationIterator.HasCurrent)
            {
                onRightOnly(destinationIterator.Current);
                destinationIterator.MoveNext();
            }
        }
    }
    internal class EnumerableIterator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        public EnumerableIterator(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
            MoveNext();
        }
        public bool HasCurrent { get; private set; }
        public T Current
        {
            get { return _enumerator.Current; }
        }
        public void MoveNext()
        {
            HasCurrent = _enumerator.MoveNext();
        }
    }
