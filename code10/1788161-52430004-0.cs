    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileStream, false))
        {
            WorkbookPart workbookPart = document.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            SharedStringTablePart stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            var headerRow = sheetData.Elements<Row>().FirstOrDefault();
            foreach (Cell c in headerRow.Elements<Cell>())
            {
                string cellText;
                if (c.DataType == CellValues.SharedString)
                {
                    //the value will be a number which is an index into the shared strings table
                    int index = int.Parse(c.CellValue.InnerText);
                    cellText = stringTable.SharedStringTable.ElementAt(index).InnerText;
                }
                else
                {
                    //just take the value from the cell (note this won't work for some types e.g. dates)
                    cellText = c.CellValue.InnerText;
                }
                Console.WriteLine(cellText);
            }
                    
        }
    }
	
