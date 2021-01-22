    public static readonly DependencyProperty ObjectWidthProperty = DependencyProperty.Register(
	    "ObjectWidth",
		typeof(double),
		typeof(MainPage),
		new PropertyMetadata(50.0, new PropertyChangedCallback(OnObjectWidthChanged)));
	public double ObjectWidth
	{
		get { return (double)GetValue(ObjectWidthProperty); }
		set { SetValue(ObjectWidthProperty, value); }
	}
	private static void OnObjectWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MainPage)d).OnObjectWidthChanged(e);
	}
	private void OnObjectWidthChanged(DependencyPropertyChangedEventArgs e)
	{
		this.objectA.Width = this.ObjectWidth;
	}
