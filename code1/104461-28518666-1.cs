    protected RedirectTypeConverter( Type type )
    {
        _type = type;
    }
     
    // Other methods are implemented similarly.
    public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value )
    {
        InitializeConverter();
        return _converter.ConvertFrom( context, culture, value );
    }
     
    public void InitializeConverter()
    {
        if ( _converter != null )
        {
            return;
        }
     
        _converter = TypeDescriptor.GetConverter( _type );
        if ( _converter.GetType() == GetType() )
        {
            string message = string.Format(
              "Conversion failed. Converter for {0} is missing in TypeDescriptor.", _type );
            throw new InvalidOperationException( message );
        }
    }
