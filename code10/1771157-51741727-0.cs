    void Main()
    {
    	var fileName = @"c:\temp\openxml-read-row.xlsx";
    	
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
    		{
    	
    			// Get the necessary bits of the doc
    			WorkbookPart workbookPart = doc.WorkbookPart;
    			SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
    			SharedStringTable sst = sstpart.SharedStringTable;
    			WorkbookStylesPart ssp = workbookPart.GetPartsOfType<WorkbookStylesPart>().First();
    			Stylesheet ss = ssp.Stylesheet;
    			
    			// Get the first worksheet
    			WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
    			Worksheet sheet = worksheetPart.Worksheet;
    	
    			var rows = sheet.Descendants<Row>();
                var row = rows.First();
    	        foreach (var cell in row.Descendants<Cell>())
                {
                    var txt = GetCellText(cell, sst);
                    $"{cell.CellReference} = {txt}".Dump();
                }
    		}
    	}	
    }
    
    // Very basic way to get the text of a cell
    private string GetCellText(Cell cell, SharedStringTable sst)
    {
    	if (cell == null)
    		return "";
    		
    	if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
    	{
    		int ssid = int.Parse(cell.CellValue.Text);
    		string str = sst.ChildElements[ssid].InnerText;
    		return str;
    	}
    	else if (cell.CellValue != null)
    	{
    		return cell.CellValue.Text;
    	}
    	return "";
    }
