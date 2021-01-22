	public static readonly DependencyProperty SomeProperty =
		DependencyProperty.Register(
			"Some", typeof(ObservableCollection<IModel>),
			typeof(SomeUserControl),
			new PropertyMetadata()
			{
				DefaultValue = null,
				PropertyChangedCallback = OnSomeChanged,
				CoerceValueCallback = OnCoerceSome
			}
		);
	private static object OnCoerceSome(DependencyObject d, object baseValue)
	{
		var v = (ObservableCollection<IModel>)baseValue;
		return v ?? new ObservableCollection<IModel>();
	}   
