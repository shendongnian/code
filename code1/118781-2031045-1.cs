    class MyClass<T>
    {
        private readonly Func<string,T> ParseEntry;
        public MyClass( Func<string,T> parser )    
        {
            ParseEntry = parser;
        }
    }
    public static class AvailableParsers
    {
        public static Func<string,int> ParseInt = s => int.Parse( s );
        public static Func<string,float> ParseFloat = s => float.Parse(s);
    }
