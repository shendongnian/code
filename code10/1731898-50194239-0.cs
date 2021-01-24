	public static readonly DependencyProperty KlickParameterProperty = DependencyProperty.Register( nameof(KlickParameter), typeof(object), typeof(userControl), new PropertyMetadata( default(object) ) );
	public object KlickParameter
	{
	    get { return GetValue( KlickParameterProperty ); }
	    set { SetValue( KlickParameterProperty, value ); }
	}
