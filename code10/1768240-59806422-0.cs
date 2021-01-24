    using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Spreadsheet;
	using DocumentFormat.OpenXml;
	......
	public static void ExportDataSetToExcellWithColour_openXML(DataSet ds, string destination)
        {
            if (File.Exists(destination))
            {
                try
                {
                    File.SetAttributes(destination, FileAttributes.Normal);
                    File.Delete(destination);
                }
                catch { }
            }
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();
                #region deal with color
                List<string> colorCode = new List<string>();
                foreach (global::System.Data.DataTable table in ds.Tables)
                {
                    if (table.Columns.Contains("color"))
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            if (!colorCode.Contains(dr["color"].ToString()))
                            {
                                colorCode.Add(dr["color"].ToString());
                            }
                        }
                    }
                }
                WorkbookStylesPart stylePart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = CreateStylesheet(colorCode);
                //stylePart.Stylesheet = CreateStylesheet_ori();
                stylePart.Stylesheet.Save();
                #endregion
                foreach (global::System.Data.DataTable table in ds.Tables)
                {
                    DataTable ori_dt = null;
                    if (table.Columns.Contains("color"))
                    {
                        ori_dt = table.Clone();
                        foreach (DataRow dr in table.Rows)
                        {
                            ori_dt.Rows.Add(dr.ItemArray);
                        }
                        table.Columns.Remove("color");
                    }
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);
                    uint sheetId = 1;
                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }
                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);
                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    List<String> columns = new List<string>();
                    foreach (global::System.Data.DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(headerRow);
                    int rowindex = 0;
                    foreach (global::System.Data.DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                            if (ori_dt.Columns.Contains("color"))
                            {
                                try
                                {
                                    cell.StyleIndex =
                                        (
                                            (UInt32)colorCode.FindIndex(
                                                a => a == ori_dt.Rows[rowindex]["color"].ToString()
                                            )
                                        ) + 1;
                                    //cell.StyleIndex = (UInt32)2;
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                        rowindex++;
                    }
                }
            }
        }
        public static Stylesheet CreateStylesheet(List<string> colorCode)
        {
            Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            DocumentFormat.OpenXml.Spreadsheet.Fonts fonts1 = new DocumentFormat.OpenXml.Spreadsheet.Fonts() { Count = (UInt32Value)1U, KnownFonts = true };
            DocumentFormat.OpenXml.Spreadsheet.Font font1 = new DocumentFormat.OpenXml.Spreadsheet.Font();
            DocumentFormat.OpenXml.Spreadsheet.FontSize fontSize1 = new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 11D };
            DocumentFormat.OpenXml.Spreadsheet.Color color1 = new DocumentFormat.OpenXml.Spreadsheet.Color() { Theme = (UInt32Value)1U };
            DocumentFormat.OpenXml.Spreadsheet.FontName fontName1 = new DocumentFormat.OpenXml.Spreadsheet.FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };
            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);
            fonts1.Append(font1);
            Fills fills1 = new Fills() { Count = (UInt32)(colorCode.Count + 2) };
            // FillId = 0
            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };
            fill1.Append(patternFill1);
            fills1.Append(fill1);
            // FillId = 1
            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };
            fill2.Append(patternFill2);
            fills1.Append(fill2);
            foreach (string color in colorCode)
            {
                Fill fill5 = new Fill();
                PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
                ForegroundColor foregroundColor3 = new ForegroundColor() { Rgb = color.Replace("#", "") };
                BackgroundColor backgroundColor3 = new BackgroundColor() { Indexed = (UInt32Value)64U };
                patternFill5.Append(foregroundColor3);
                patternFill5.Append(backgroundColor3);
                fill5.Append(patternFill5);
                fills1.Append(fill5);
            }
            Borders borders1 = new Borders() { Count = (UInt32Value)1U };
            DocumentFormat.OpenXml.Spreadsheet.Border border1 = new DocumentFormat.OpenXml.Spreadsheet.Border();
            DocumentFormat.OpenXml.Spreadsheet.LeftBorder leftBorder1 = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder();
            DocumentFormat.OpenXml.Spreadsheet.RightBorder rightBorder1 = new DocumentFormat.OpenXml.Spreadsheet.RightBorder();
            DocumentFormat.OpenXml.Spreadsheet.TopBorder topBorder1 = new DocumentFormat.OpenXml.Spreadsheet.TopBorder();
            DocumentFormat.OpenXml.Spreadsheet.BottomBorder bottomBorder1 = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder();
            DocumentFormat.OpenXml.Spreadsheet.DiagonalBorder diagonalBorder1 = new DocumentFormat.OpenXml.Spreadsheet.DiagonalBorder();
            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);
            borders1.Append(border1);
            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };
            cellStyleFormats1.Append(cellFormat1);
            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32)(colorCode.Count + 1) };
            CellFormat cellFormat0 = new CellFormat()
            {
                NumberFormatId = (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32)0,
                BorderId = (UInt32Value)0U,
                FormatId = (UInt32Value)0U,
                ApplyFill = true
            };
            cellFormats1.Append(cellFormat0);
            int colorCodeIndex = 0;
            foreach (string color in colorCode)
            {
                CellFormat cellFormat5 = new CellFormat()
                {
                    NumberFormatId = (UInt32Value)0U,
                    FontId = (UInt32Value)0U,
                    FillId = (UInt32)(colorCodeIndex + 2),
                    BorderId = (UInt32Value)0U,
                    FormatId = (UInt32Value)0U,
                    ApplyFill = true
                };
                cellFormats1.Append(cellFormat5);
                colorCodeIndex++;
            }
            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };
            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleMedium9" };
            StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();
            StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            DocumentFormat.OpenXml.Office2010.Excel.SlicerStyles slicerStyles1 = new DocumentFormat.OpenXml.Office2010.Excel.SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" };
            stylesheetExtension1.Append(slicerStyles1);
            stylesheetExtensionList1.Append(stylesheetExtension1);
            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(stylesheetExtensionList1);
            return stylesheet1;
        }
