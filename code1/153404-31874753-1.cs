    using (var spreadSheet = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
    {
        // Workbook
        var workbookPart = spreadSheet.AddWorkbookPart();
        workbookPart.Workbook =
            new Workbook(new Sheets(new Sheet { Name = "Sheet1", SheetId = (UInt32Value) 1U, Id = "rId1" }));
    
        // Add minimal Stylesheet
        var stylesPart = spreadSheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        stylesPart.Stylesheet = new Stylesheet
        {
            Fonts = new Fonts(new Font()),
            Fills = new Fills(new Fill()),
            Borders = new Borders(new Border()),
            CellStyleFormats = new CellStyleFormats(new CellFormat()),
            CellFormats =
                new CellFormats(
                    new CellFormat(),
                    new CellFormat
                    {
                        NumberFormatId = 14,
                        ApplyNumberFormat = true
                    })
        };
    	
    	// Continue creating `WorksheetPart`...
