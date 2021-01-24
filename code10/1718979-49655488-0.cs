	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MyFAB), null);
	public ICommand Command
	{
		get { return (ICommand)GetValue(CommandProperty); }
		set { SetValue(CommandProperty, value); }
	} 
	
	// Adding support to command parameters
	public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MyFAB), null);
	public object CommandParameter
	{
		get { return GetValue(CommandParameterProperty); }
		set { SetValue(CommandParameterProperty, value); }
	}
