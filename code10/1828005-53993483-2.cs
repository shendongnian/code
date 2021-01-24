    public string GetCellValue(SpreadsheetDocument document, Cell cell)
    {
    	SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
    	string value = string.Empty;
    	if (cell.CellValue != null)
    	{
    		value = cell.CellValue.InnerXml;
    		if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
    		{
    			value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
    		}
    
    	}
    	return value;
    }
