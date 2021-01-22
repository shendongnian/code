    public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value )
    {
	    var typeProvider =
          (IDestinationTypeProvider)context.GetService( typeof( IDestinationTypeProvider ) );
    	Type targetType = typeProvider.GetDestinationType();
        // ... do stuff
        return base.ConvertFrom( context, culture, value );
    }
