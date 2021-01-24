	class Program
	{
		static void Main(string[] args)
		{
			int rowStart = 1;
			string colStart = "Y";
			int rowEnd = 5;
			string colEnd = "AC";
			string currentRow = colStart;
			bool done = false;
			// check if rowStart < rowEnd && colStart < colEnd
			using (document = SpreadsheetDocument.Open(filePath, true))
			{
				WorkbookPart wbPart = document.WorkbookPart;
				Worksheet sheet = wbPart.WorksheetParts.First().Worksheet;
				for (; ; )
				{
					for (int i = rowStart; i <= rowEnd; i++)
					{
						// Your cell
						Cell cell = GetCell(sheet, currentRow, i);
					}
					currentRow = GetNextColumn(currentRow);
					if (done)
					{
						break;
					}
					if (currentRow == colEnd)
					{
						done = true;
					}
				}
			}
			Console.Read();
		}
		private static Cell GetCell(Worksheet worksheet,
			string columnName, uint rowIndex)
		{
			Row row = GetRow(worksheet, rowIndex);
			if (row == null)
				return null;
			return row.Elements<Cell>().Where(c => string.Compare
												   (c.CellReference.Value, columnName +
																		   rowIndex, true) == 0).First();
		}
		// Given a worksheet and a row index, return the row.
		private static Row GetRow(Worksheet worksheet, uint rowIndex)
		{
			return worksheet.GetFirstChild<SheetData>().
				Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
		}
		static string GetNextColumn(string col)
		{
			char[] charArr = col.ToCharArray();
			var cur = Convert.ToChar((int) charArr[charArr.Length - 1]);
			if (cur == 'Z')
			{
				if (charArr.Length == 1)
				{
					return "AA";
				}
				else
				{
					char[] newArray = charArr.Take(charArr.Length - 1).ToArray();
					var ret = GetNextColumn(new string(newArray));
					return ret + "A";
				}
			}
			charArr[charArr.Length - 1] = Convert.ToChar((int)charArr[charArr.Length - 1] + 1);
			return new string(charArr);
		}
	}
