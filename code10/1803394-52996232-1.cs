    public static String ToStringInvariant<T>( this T value )
        where T : IConvertible
    {
        return value.ToString( c, CultureInfo.InvariantCulture );
    }
    
