    public class EnumerableDispose<T> : IEnumerable<T>, IDisposable
        where T : IDisposable
    {
        public EnumerableDispose(IEnumerable<T> source)
        {
            // TODO: implement
        }
    }
