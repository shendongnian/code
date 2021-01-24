    Button btn = new Button()
	{
		FontSize = 12,
		Content = "button text",
		InputBindings =
		{
			{ "click", (Delegate)(MouseButtonEventHandler)( delegate(Object s, MouseButtonEventArgs e) { DisplayFoo("clicked!"); } ) }
		}
	};
