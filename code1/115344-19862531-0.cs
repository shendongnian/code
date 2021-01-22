    private bool HasFocus { get; set; }
	protected override void OnGotFocus( RoutedEventArgs e )
	{
		base.OnGotFocus( e );
		HasFocus = true;
	}
	protected override void OnLostFocus( RoutedEventArgs e )
	{
		base.OnLostFocus( e );
		HasFocus = false;
	}
