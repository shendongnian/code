    abstract class ColFilter<T> 
    {
        abstract bool AddSingleQuotes { get; }
        List<T> Values { get; }
    }
    
    class IntColFilter<T>
    {
        override bool AddSingleQuotes { get { return false; } }    
    }
    
    class StringColFilter<T>
    {
        override bool AddSingleQuotes { get { return true; } }
    }
    
    class SomeOtherClass 
    {
        public static string BuildClause<T>(string prefix, ColFilter<T> filter)
        {
            return BuildClause(prefix, filter.Values, filter.AddSingleQuotes);
        }
    
        public static string BuildClause<T>(string prefix, IList<T> values, bool addSingleQuotes) 
        {
            // use your existing implementation, since here we don't care about types anymore -- 
            // all we do is call ToString() on them.
            // in fact, we don't need this method to be generic at all!
        }
    }
