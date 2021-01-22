    public static IQueryable<T> EqualIfNotEmpty( IQueryable<T> source, string column, string text )
    {
         if (string.IsNullOrEmpty( text ))
         {
             return source;
         }
         return source.Where( string.Format( "{0} == {1}", column, text ) );
    }
    customers = MyDataContext.Customers
                             .EqualIfNotEmpty( "Email", input );
         
