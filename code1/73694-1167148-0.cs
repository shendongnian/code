    public interface IFunctionCache
    {
        void InvalidateAll();
        // we could add more overloads here...
    }
    
    public static class Function
    {
        public class OpaqueKey<A, B>
        {
            private readonly object m_Key;
    
            public A First { get; private set; }
            public B Second { get; private set; }
    
            public OpaqueKey(A k1, B k2)
            {
                m_Key = new { K1 = k1, K2 = k2 };
                First = k1;
                Second = k2;
            }
    
            public override bool Equals(object obj)
            {
                var otherKey = obj as OpaqueKey<A, B>;
                return otherKey == null ? false : m_Key.Equals(otherKey.m_Key);
            }
    
            public override int GetHashCode()
            {
                return m_Key.GetHashCode();
            }
        }
    
        private class AutoCache<TArgs,TR> : IFunctionCache
        {
            private readonly Dictionary<TArgs,TR> m_CachedResults 
                = new Dictionary<TArgs, TR>();
    
            public bool IsCached( TArgs arg1 )
            {
                return m_CachedResults.ContainsKey( arg1 );
            }
    
            public TR AddCachedValue( TArgs arg1, TR value )
            {
                m_CachedResults.Add( arg1, value );
                return value;
            }
    
            public TR GetCachedValue( TArgs arg1 )
            {
                return m_CachedResults[arg1];
            }
    
            public void InvalidateAll()
            {
                m_CachedResults.Clear();
            }
        }
    
        public static Func<A,TR> AsCacheable<A,TR>( this Func<A,TR> function )
        {
            IFunctionCache ignored;
            return AsCacheable( function, out ignored );
        }
    
        public static Func<A, TR> AsCacheable<A, TR>( this Func<A, TR> function, out IFunctionCache cache)
        {
            var autocache = new AutoCache<A,TR>();
            cache = autocache;
            return (a => autocache.IsCached(a) ?
                         autocache.GetCachedValue(a) :
                         autocache.AddCachedValue(a, function(a)));
        }
    
        public static Func<A,B,TR> AsCacheable<A,B,TR>( this Func<A,B,TR> function )
        {
            IFunctionCache ignored;
            return AsCacheable(function, out ignored);
        }
    
        public static Func<A,B,TR> AsCacheable<A,B,TR>( this Func<A,B,TR> function, out IFunctionCache cache )
        {
            var autocache = new AutoCache<OpaqueKey<A, B>, TR>();
            cache = autocache;
            return ( a, b ) =>
                       {
                           var key = new OpaqueKey<A, B>( a, b );
                           return autocache.IsCached(key)
                                      ? autocache.GetCachedValue(key)
                                      : autocache.AddCachedValue(key, function(a, b));
                       };
        }
    }
    
    public class CacheableFunctionTests
    {
        public static void Main( string[] args )
        {
            Func<string, string> Reversal = s => new string( s.Reverse().ToArray() );
    
            var CacheableReverse = Reversal.AsCacheable();
    
            var reverse1 = CacheableReverse("Hello");
            var reverse2 = CacheableReverse("Hello"); // step through to prove it uses caching
    
            Func<int, int, double> Average = (a,b) => (a + b)/2.0;
            var CacheableAverage = Average.AsCacheable();
    
            var average1 = CacheableAverage(2, 4);
            var average2 = CacheableAverage(2, 4);
        }
    }
