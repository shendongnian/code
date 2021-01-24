    private void CreateExcelTableBodyCellSymbolCircle(IXLWorksheet worksheet, string cellID, XLColor colour)
    {
        string circleSymbol = char.ConvertFromUtf32(0x006C);
        PopulateExcelTableCellWithSymbol(worksheet, cellID, colour, circleSymbol);
    }
    
    private void PopulateExcelTableCellWithSymbol(IXLWorksheet worksheet, string cellID, XLColor colour, string symbolValue)
    {
        worksheet.Cell(cellID).DataType = XLCellValues.Text;
        worksheet.Cell(cellID).Value = symbolValue;
        worksheet.Cell(cellID).Style.Font.SetFontName("Wingdings");
        worksheet.Cell(cellID).Style.Font.SetFontColor(colour);
    }
