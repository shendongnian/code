    Button btn = new Button()
	{
		FontSize = 12,
		Content = "button text",
		InputBindings =
		{
			{ "click", (MouseButtonEventHandler)( (s, e) => DisplayFoo("clicked!") ) }
		}
	};
