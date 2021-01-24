	public static readonly DependencyProperty KlickProperty = DependencyProperty.Register( nameof(Klick), typeof(ICommand), typeof(userControl), new PropertyMetadata( default(ICommand) ) );
	public ICommand Klick
	{
	    get { return (ICommand)GetValue( KlickProperty ); }
	    set { SetValue( KlickProperty, value ); }
	}
