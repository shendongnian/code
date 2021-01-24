    private Cell AddCellWithValue(string value, CellValues type)
    {
    	var cell = new Cell
    	{
    		DataType = type
    	};
    	if (type == CellValues.InlineString)
    	{
    		var inlineString = new InlineString();
    		var t = new Text
    		{
    			Text = value
    		};
    		inlineString.AppendChild(t);
    		cell.AppendChild(inlineString);
    	}
    	else
    	{
    		cell.CellValue = new CellValue(value);
    	}
    	return cell;
    }
