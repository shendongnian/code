    public class Pair<TSource, TResult>
    {
        public TSource Source { get; set; }
        public TResult Result { get; set; }
        public Pair() {}
        public Pair(TSource source, TResult result)
        {
            Source = source;
            Result = result;
        }
        // Perhaps override Equals() and GetHashCode() as well
    }
