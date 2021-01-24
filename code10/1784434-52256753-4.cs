             using (MemoryStream mem = new MemoryStream())
          {
            using (var document = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook))
            {
              var workbookPart = document.AddWorkbookPart();
              workbookPart.Workbook = new Workbook();
    
              var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
              worksheetPart.Worksheet = new Worksheet();
    
             
              var sheets = workbookPart.Workbook.AppendChild(new Sheets());
              var sheet = new Sheet
              {
                Id = workbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Report"
              };
              sheets.Append(new[] { sheet });
              workbookPart.Workbook.Save();
    
              var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
              // Constructing header
              var row = new Row();
              // This needs to get adjusted for your needs
              // it returns IEnumerable<Cell>
              row.Append(GenerateHeaderCells(/*FillMe*/));
    
              // Insert the header row to the Sheet Data
              sheetData.AppendChild(row);
    
              foreach (var entity in data)
              {
    
                row = new Row();
    //This needs to get adjusted
    // it returns IEnumerable<Cell>
                row.Append(GenerateCells(/*FillMe*/));
    
                sheetData.AppendChild(row);
              }
              worksheetPart.Worksheet.Save();
            }
    
            return mem.ToArray();
          }
