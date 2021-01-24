	public Cell CreateInlineTextCell(string columnName, int rowIndex, string input)
	{
		string cellReference = columnName + rowIndex;
		var cell = new Cell
		{
			DataType = CellValues.InlineString,
			CellReference = cellReference
		};
		var inlineString = new InlineString();
		var text = new Text { Text = input };
		inlineString.AppendChild(text);
		cell.AppendChild(inlineString);
		
		return cell;
	}
