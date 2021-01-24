    using (SpreadsheetDocument document = SpreadsheetDocument.Open(@"D:\test.xlsx", true))
    {
    	WorkbookPart wbPart = document.WorkbookPart;
    	List<WorksheetPart> wsParts = wbPart.WorksheetParts.ToList();
    	if (wsParts != null && wsParts.Any())
    	{
    		WorksheetPart SheetPart1 = wsParts.First();
    		MergeCells mergeCells = SheetPart1.Worksheet.Elements<MergeCells>().First();
    		foreach (MergeCell mergeCell in mergeCells)
    		{
    			string[] mergedRow = mergeCell.Reference.Value.Split(new string[]{":"},StringSplitOptions.None);
    			Cell theCell = SheetPart1.Worksheet.Descendants<Cell>().
    				Where(c => c.CellReference == mergedRow[0]).FirstOrDefault();
    			string value = GetCellValue(document, theCell);
    		}
    	}
    }
