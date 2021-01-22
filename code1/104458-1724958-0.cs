    public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value )
    {
    	var provider = (IServiceProvider)context;
	    var typeProvider =
          (IDestinationTypeProvider)provider.GetService( typeof( IDestinationTypeProvider ) );
    	Type targetType = typeProvider.GetDestinationType();
        // ... do stuff
        return base.ConvertFrom( context, culture, value );
    }
