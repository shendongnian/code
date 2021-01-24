	static void Main(string[] args)
	{
		int rowStart = 4;
		string colStart = "Q";
		int rowEnd = 89;
		string colEnd = "AD";
		string currentRow = colStart;
		// make sure rowStart < rowEnd && colStart < colEnd
		using (document = SpreadsheetDocument.Open(filePath, true))
		{
			WorkbookPart wbPart = document.WorkbookPart;
			Worksheet sheet = wbPart.WorksheetParts.First().Worksheet;
			while(currentRow != GetNextColumn(colEnd))
			{
				for (int i = rowStart; i <= rowEnd; i++)
				{
					Cell cell = GetCell(sheet, currentRow, i);
				}
				currentRow = GetNextColumn(currentRow);
			}
		}
		Console.Read();
	}
	
