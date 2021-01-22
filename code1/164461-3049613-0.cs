	public override object ProvideValue( IServiceProvider serviceProvider ) {
		IProvideValueTarget valueProvider = (IProvideValueTarget)serviceProvider.GetService( typeof( IProvideValueTarget ) );
		object @target = valueProvider.TargetObject;
		object @property = valueProvider.TargetProperty;
		MultiBinding result = new MultiBinding();
        // set up binding as per custom logic...
		BindingOperations.SetBinding( (DependencyObject)@target, (DependencyProperty)@property, result );
		return result.ProvideValue( serviceProvider );
	}
