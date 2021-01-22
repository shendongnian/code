    /// <summary>
    /// Attempts to convert a value using any customer TypeConverters applied to the member
    /// </summary>
    /// <param name="value">Object containing the value to be assigned</param>
    /// <param name="member">Member to be assigned to</param>
    /// <returns><paramref name="value"/> converted to the appropriate type</returns>
    public static Object CustomTypeConversion ( object value, MemberInfo member )
    {
        if ( value == null || value == DBNull.Value )
            return value;
    
        if ( member == null )
            throw new ArgumentNullException ( );
    
        List<TypeConverter> converters = GetCustomTypeConverters ( member );
    
        foreach ( TypeConverter c in converters )
        {
            if ( c.CanConvertFrom ( value.GetType ( ) ) )
                return c.ConvertFrom ( value );
        }
    
        if ( member is PropertyInfo )
        {
            PropertyInfo prop = member as PropertyInfo;
            return ConvertToNative( value , prop.PropertyType );
        }
        return ConvertToNative ( value, member.MemberType.GetType ( ) );
    }
    
    /// <summary>
    /// Extracts and instantiates any customer type converters assigned to a 
    /// derivitive of the <see cref="System.Reflection.MemberInfo"/> property
    /// </summary>
    /// <param name="member">Any class deriving from MemberInfo</param>
    /// <returns>A list of customer type converters, empty if none found</returns>
    public static List<TypeConverter> GetCustomTypeConverters ( System.Reflection.MemberInfo member )
    {
        List<TypeConverter> result = new List<TypeConverter>();
    
        try
        {
            foreach ( TypeConverterAttribute a in member.GetCustomAttributes( typeof( TypeConverterAttribute ) , true ) )
            {
                TypeConverter converter = Activator.CreateInstance( Type.GetType( a.ConverterTypeName ) ) as TypeConverter;
    
                if ( converter != null )
                    result.Add( converter );
            }
        }
        catch
        {
            // Let it go, there were no custom converters
        }
    
        return result;
    }
    
    /// <summary>
    /// Attempts to cast the incoming database field to the property type
    /// </summary>
    /// <param name="value">Database value to cast</param>
    /// <param name="castTo">Type to cast to</param>
    /// <returns>The converted value, if conversion failed the original value will be returned</returns>
    public static object ConvertToNative ( object value , Type castTo )
    {
        try
        {
            return Convert.ChangeType( value , castTo , System.Threading.Thread.CurrentThread.CurrentCulture );
        }
        catch
        {
            return value;
        }
    }
