        private void btnAddFillColor_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Test\\OpenXMLTest_NoFillColor.xlsx";
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, true))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                WorksheetPart wsPart = wbPart.WorksheetParts.FirstOrDefault();
                WorkbookStylesPart stylesPart = document.WorkbookPart.WorkbookStylesPart;
                ChangeWorkbookStylesPart(stylesPart);
                ChangeWorksheetPart(wsPart);
            }
        }
        private void ChangeWorkbookStylesPart(WorkbookStylesPart workbookStylesPart1)
        {
            xl.Stylesheet stylesheet1 = workbookStylesPart1.Stylesheet;
            xl.Fills fills1 = stylesheet1.GetFirstChild<xl.Fills>();
            xl.CellFormats cellFormats1 = stylesheet1.GetFirstChild<xl.CellFormats>();
            fills1.Count = (UInt32Value)3U;
            xl.Fill fill1 = new xl.Fill();
            xl.PatternFill patternFill1 = new xl.PatternFill() { PatternType = xl.PatternValues.Solid };
            xl.ForegroundColor foregroundColor1 = new xl.ForegroundColor() { Rgb = "FFC00000" };
            xl.BackgroundColor backgroundColor1 = new xl.BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill1.Append(patternFill1);
            fills1.Append(fill1);
            cellFormats1.Count = (UInt32Value)2U;
            xl.CellFormat cellFormat1 = new xl.CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true };
            cellFormats1.Append(cellFormat1);
        }
        private void ChangeWorksheetPart(WorksheetPart worksheetPart1)
        {
            xl.Worksheet worksheet1 = worksheetPart1.Worksheet;
            xl.SheetData sheetData1 = worksheet1.GetFirstChild<xl.SheetData>();
            xl.Row row1 = sheetData1.GetFirstChild<xl.Row>();
            xl.Cell cell1 = row1.GetFirstChild<xl.Cell>();
            cell1.StyleIndex = (UInt32Value)1U;
        }
