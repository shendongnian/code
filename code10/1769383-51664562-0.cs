	private ModInlineUIContainer CreateContainer(string text, Action mouseDoubleClick)
	{
		var label = new InlineLabel(text);
		var container = new ModInlineUIContainer(label);
		
		label.MouseDoubleClick += (s, e) => mouseDoubleClick();
		
		return container;
	}
