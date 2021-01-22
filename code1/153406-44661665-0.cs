	using (SpreadsheetDocument document = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook))
    {
        //fluff to generate the workbook etc
	    WorkbookPart workbookPart = document.AddWorkbookPart();
	    workbookPart.Workbook = new Workbook();
	    var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
	    worksheetPart.Worksheet = new Worksheet();
				
	    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
	    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet" };
	    sheets.Append(sheet);
	    workbookPart.Workbook.Save();
	    var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
        //add the style
        Stylesheet styleSheet = new Stylesheet();
        CellFormat cf = new CellFormat();
        cf.NumberFormatId = 14;
        cf.ApplyNumberFormat = true;
        CellFormats cfs = new CellFormats();
        cfs.Append(cf);
        styleSheet.CellFormats = cfs;
        styleSheet.Borders = new Borders();
        styleSheet.Borders.Append(new Border());
        styleSheet.Fills = new Fills();
        styleSheet.Fills.Append(new Fill());
        styleSheet.Fonts = new Fonts();
        styleSheet.Fonts.Append(new Font());
        workbookPart.AddNewPart<WorkbookStylesPart>();
        workbookPart.WorkbookStylesPart.Stylesheet = styleSheet;
        CellStyles css = new CellStyles();
        CellStyle cs = new CellStyle();
        cs.FormatId = 0;
        cs.BuiltinId = 0;
        css.Append(cs);
        css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
        styleSheet.Append(css);
        Row row = new Row();
        DateTime date = new DateTime(2017, 6, 24);
        /*** Date code here ***/
        //write an OADate with type of Number
        Cell cell1 = new Cell();
        cell1.CellReference = "A1";
        cell1.CellValue = new CellValue(date.ToOADate().ToString());
        cell1.DataType = new EnumValue<CellValues>(CellValues.Number);
        cell1.StyleIndex = 0;
        row.Append(cell1);
        //write an OADate with no type (defaults to Number)
        Cell cell2 = new Cell();
        cell2.CellReference = "B1";
        cell2.CellValue = new CellValue(date.ToOADate().ToString());
        cell1.StyleIndex = 0;
        row.Append(cell2);
        //write an ISO 8601 date with type of Date
        Cell cell3 = new Cell();
        cell3.CellReference = "C1";
        cell3.CellValue = new CellValue(date.ToString("yyyy-MM-dd"));
        cell3.DataType = new EnumValue<CellValues>(CellValues.Date);
        cell1.StyleIndex = 0;
        row.Append(cell3);
                
        sheetData.AppendChild(row);
                
        worksheetPart.Worksheet.Save();
    }
