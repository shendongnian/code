    public static TResult ConvertTo<TResult>( this string source )
    {
         if( !typeof(TResult).IsEnum )
         {
             throw new NotSupportedException( "TResult must be an Enum" );
         }
         return (TResult)Enum.Parse( typeof(TResult), source );
    }
