	public override object ProvideValue( IServiceProvider serviceProvider ) {
		IProvideValueTarget valueProvider = (IProvideValueTarget)serviceProvider.GetService( typeof( IProvideValueTarget ) );
        // only need to do this if they're needed in your logic:
		object @target = valueProvider.TargetObject;
		object @property = valueProvider.TargetProperty;
		MultiBinding result = new MultiBinding();
        // set up binding as per custom logic...
		return result.ProvideValue( serviceProvider );
	}
