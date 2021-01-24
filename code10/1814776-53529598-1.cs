    class DataClass 
    {
        …
        static public Expression<Func<DataClass,bool>> MatchSelectedFields( string text, bool ignoreCase) 
        {
             return @this => (
                 String.Equals( text, @this.PropertyOne, (ignoreCase? StringComparison.OrdinalIgnoreCase: StringComparison.Ordinal)) 
                 || String.Equals( text, @this.Child.PropertyThree, (ignoreCase? StringComparison.OrdinalIgnoreCase: StringComparison.Ordinal))
             );
        }
    }
