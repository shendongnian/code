    // Predicate must be a method with a single parameter,
    // so we must pass the other parameter in constructor
    public class UriMatcher
    {
        private readonly Uri _u;
        public UriMatcher(Uri u)
        {
            _u = u;
        }
        // Match is Predicate<CustomClass>
        public bool Match(CustomClass cc)
        {
            return cc.Path == _u;
        }
    }
