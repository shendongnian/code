	Button btn = new Button()
	{
		FontSize = 12,
		Content = "button text",
		InputBindings =
		{
			{ Button.ClickEvent, (s, e) => DisplayFoo("clicked!") },
			{ Button.LoadedEvent, (s, e) => DisplayFoo("loaded!") },
			{ nameof(Button.ContextMenuClosing), (ContextMenuEventHandler)((s,e) => DisplayFoo("context menu closing")) },
			{ (Button b) => b.Click += (s, e) => DisplayFoo("clicked 3!") },
			{ (Button b) =>
			{
				b.Click += (s, e) => DisplayFoo("clicked 3!");
				b.ContextMenuClosing += (s, e) => DisplayFoo("context menu closing 2");
			} }
		}
	};
