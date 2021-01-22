    static class HapExtensions
    {
        public IEnumerable<T> SkipUntilAfter( this IEnumerable<T> sequence, Predicate<T> predicate) {
            return sequence.SkipWhile( predicate).Skip(1);
           }
    }
    
