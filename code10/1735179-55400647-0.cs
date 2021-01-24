	private void PaViewAutoGeneratingColumnHandler(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
		var columnName = (string)e.Column.Header;
		// We'll build a string with escaped characters.
		// The capacity is the length times 2 (for the carets),
		// plus 2 for the square brackets.
		// This is not optimized for multi-character glyphs, like emojis
		var bindingBuilder = new StringBuilder(columnName.Length * 2 + 2);
		bindingBuilder.Append('[');
		foreach (var c in columnName)
		{
			bindingBuilder.Append('^');
			bindingBuilder.Append(c);
		}
		bindingBuilder.Append(']');
		e.Column = new DataGridTextColumn
		{
			Binding = new Binding(bindingBuilder.ToString()),
			Header = e.Column.Header,
		};
    }
