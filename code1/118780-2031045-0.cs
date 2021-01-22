    class MyClass<T>
    {
        private static readonly Func<string,T> ParseEntry;
        static MyClass<T>()    
        {
            ParseEntry = default(T).AcquireParser();           
        }
    }
    public static class ParserExtensions  
    {
        public static Func<string,int> AcquireParser( this int value )
        {
            return s => int.ParseEntry( s );
        }
        public static Func<string,float> AcquireParser( this long value )
        {
            return s => long.ParseEntry( s );
        }
        // all other overloads
    }
