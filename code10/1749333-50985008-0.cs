    public static void MergeXSLX(string spreadSheetPathSource, string spreadSheetPathDestination)
        {
            //string[] staticSheets = new string[] { "Index", "Proj Info", "Project Report", "Cust Proj Rpt", "Issues Register", "Risk Register", "Change Register", "Milestones Register", "Add Optional Sheets ==>" };
            string[] staticSheets = new string[] { "Summaries", "limits" };
            FileStream spreadSheetStreamSource = null;
            FileStream spreadSheetStreamDestination = null;
            try
            {
                if (!File.Exists(spreadSheetPathSource)) throw new Exception("Source excel document not found!");
                if (!File.Exists(spreadSheetPathDestination)) throw new Exception("Destination excel document not found!");
                spreadSheetStreamSource = new FileStream(spreadSheetPathSource, FileMode.Open, FileAccess.Read);
                spreadSheetStreamDestination = new FileStream(spreadSheetPathDestination, FileMode.Open, FileAccess.ReadWrite);
                using (SpreadsheetDocument spreadsheetDocumentSource = SpreadsheetDocument.Open(spreadSheetStreamSource, false))
                {
                    using (SpreadsheetDocument spreadsheetDocumentDestination = SpreadsheetDocument.Open(spreadSheetStreamDestination, true))
                    {
                        WorkbookPart workbookPartSource = spreadsheetDocumentSource.WorkbookPart;
                        WorkbookPart workbookPartDestination = spreadsheetDocumentDestination.WorkbookPart;
                        foreach (Sheet sheet in workbookPartSource.Workbook.Sheets)
                        {
                            if (staticSheets.ToList().Contains(sheet.Name))
                            {
                                uint replaced = 0;
                                int index = 0;
                                if (workbookPartDestination.Workbook.Sheets.Elements<Sheet>().Count(s => s.Name.ToString().Equals(sheet.Name)) == 1)
                                {
                                    Sheet org;
                                    foreach (Sheet s in workbookPartDestination.Workbook.Sheets.Elements<Sheet>())
                                    {
                                        if (s.Name.ToString().Equals(sheet.Name))
                                        {
                                            org = s;
                                            break;
                                        }
                                        index++;
                                    }
                                    replaced = sheet.SheetId;
                                    DeleteWorkSheet(workbookPartDestination, sheet.Name);
                                }
                                //WorkbookPart workbookPart = mySpreadsheet.WorkbookPart;
                                ////Get the source sheet to be copied
                                WorksheetPart sourceSheetPart = GetWorkSheetPart(workbookPartSource, sheet.Name);
                                //Take advantage of AddPart for deep cloning
                                SpreadsheetDocument tempSheet = SpreadsheetDocument.Create(new MemoryStream(), spreadsheetDocumentDestination.DocumentType);
                                WorkbookPart tempWorkbookPart = tempSheet.AddWorkbookPart();
                                WorksheetPart tempWorksheetPart = tempWorkbookPart.AddPart<WorksheetPart>(sourceSheetPart);
                                if(workbookPartDestination.SharedStringTablePart == null)
                                {
                                    workbookPartDestination.AddPart<SharedStringTablePart>(workbookPartSource.SharedStringTablePart);
                                }
                                
                                //Add cloned sheet and all associated parts to workbook
                                WorksheetPart clonedSheet = workbookPartDestination.AddPart<WorksheetPart>(tempWorksheetPart);
                                //Table definition parts are somewhat special and need unique ids...so let's make an id based on count
                                int numTableDefParts = sourceSheetPart.GetPartsCountOfType<TableDefinitionPart>();
                                int tableId = numTableDefParts;
                                //Clean up table definition parts (tables need unique ids)
                                if (numTableDefParts != 0)
                                    FixupTableParts(clonedSheet, numTableDefParts);
                                //There should only be one sheet that has focus
                                CleanView(clonedSheet);
                                var values = workbookPartSource.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ToArray();
                                Dictionary<uint, uint> cacheCellFormat = new Dictionary<uint, uint>();
                                Dictionary<uint, uint> cacheCellStyleFormat = new Dictionary<uint, uint>();
                                Dictionary<uint, uint> cacheBorder = new Dictionary<uint, uint>();
                                Dictionary<uint, uint> cacheFill = new Dictionary<uint, uint>();
                                Dictionary<uint, uint> cacheFont = new Dictionary<uint, uint>();
                                Dictionary<uint, uint> cacheNumberFormat = new Dictionary<uint, uint>();
                                foreach (Cell cell in clonedSheet.Worksheet.Descendants<Cell>())
                                {
                                    if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                                    {
                                        var ssindex = int.Parse(cell.CellValue.Text);
                                        cell.CellValue = new CellValue(InsertSharedStringItem_(values[ssindex].InnerText, workbookPartDestination.SharedStringTablePart).ToString());
                                    }
                                    if (cell.StyleIndex != null)
                                    {
                                        cell.StyleIndex = GetCellFormat(workbookPartSource, workbookPartDestination, cacheCellFormat, cacheCellStyleFormat, cacheBorder, cacheFill, cacheFont, cacheNumberFormat, cell);
                                    }
                                }
                                //Add new sheet to main workbook part
                                Sheets sheets = workbookPartDestination.Workbook.GetFirstChild<Sheets>();
                                Sheet copiedSheet = new Sheet
                                {
                                    Name = sheet.Name,
                                    Id = workbookPartDestination.GetIdOfPart(clonedSheet),
                                    SheetId = (uint)sheets.ChildElements.Count + 1
                                };
                                if (replaced != 0)
                                {
                                    copiedSheet.SheetId = replaced;
                                    sheets.InsertAt(copiedSheet, index);
                                }
                                else
                                {
                                    sheets.Append(copiedSheet);
                                }
                                //Save Changes
                                workbookPartDestination.Workbook.Save();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (spreadSheetStreamSource != null)
                    spreadSheetStreamSource.Close();
                if (spreadSheetStreamDestination != null)
                    spreadSheetStreamDestination.Close();
            }
        }
        private static uint GetCellFormat(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheCellFormat, Dictionary<uint, uint> cacheCellStyleFormat, Dictionary<uint, uint> cacheBorder, Dictionary<uint, uint> cacheFill, Dictionary<uint, uint> cacheFont, Dictionary<uint, uint> cacheNumberFormat, Cell cell)
        {
            uint cellFormatIndex, cellStyleFormatIndex;
            if (cacheCellFormat.Keys.Contains(cell.StyleIndex.Value))
            {
                cellFormatIndex = cacheCellFormat[cell.StyleIndex.Value];
            }
            else
            {
                CellFormat cellFormat = workbookPartSource.WorkbookStylesPart.Stylesheet.CellFormats.Descendants<CellFormat>().ToList()[int.Parse(cell.StyleIndex)];
                CellFormat cellFormatClone = CellFormatClone(workbookPartSource, workbookPartDestination, cacheBorder, cacheFill, cacheFont, cacheNumberFormat, cellFormat);
                if (cellFormat.FormatId != 0)
                {
                    if (cacheCellStyleFormat.Keys.Contains(cellFormat.FormatId.Value))
                    {
                        cellStyleFormatIndex = cacheCellStyleFormat[cellFormat.FormatId.Value];
                    }
                    else
                    {
                        CellFormat cellStyleFormat = workbookPartSource.WorkbookStylesPart.Stylesheet.CellStyleFormats.Descendants<CellFormat>().ToList()[int.Parse(cellFormat.FormatId)];
                        if (workbookPartDestination.WorkbookStylesPart.Stylesheet.CellStyleFormats.Descendants<CellFormat>().ToList().Count > int.Parse(cellFormat.FormatId) &&
                            workbookPartDestination.WorkbookStylesPart.Stylesheet.CellStyleFormats.Descendants<CellFormat>().ToList()[int.Parse(cellFormat.FormatId)].OuterXml == cellStyleFormat.OuterXml)
                        {
                            cellStyleFormatIndex = (uint)int.Parse(cellFormat.FormatId);
                        }
                        else
                        {
                            CellFormat cellStyleFormatClone = CellFormatClone(workbookPartSource, workbookPartDestination, cacheBorder, cacheFill, cacheFont, cacheNumberFormat, cellStyleFormat);
                            workbookPartDestination.WorkbookStylesPart.Stylesheet.CellStyleFormats.Append(cellStyleFormatClone);
                            cellStyleFormatIndex = (uint)workbookPartDestination.WorkbookStylesPart.Stylesheet.CellStyleFormats.Descendants<CellFormat>().ToList().IndexOf(cellStyleFormatClone);
                            cacheCellStyleFormat.Add(cellFormat.FormatId.Value, cellStyleFormatIndex);
                        }
                    }
                    cellFormatClone.FormatId = cellStyleFormatIndex;
                }
                workbookPartDestination.WorkbookStylesPart.Stylesheet.CellFormats.Append(cellFormatClone);
                cellFormatIndex = (uint)workbookPartDestination.WorkbookStylesPart.Stylesheet.CellFormats.Descendants<CellFormat>().ToList().IndexOf(cellFormatClone);
                cacheCellFormat.Add(cell.StyleIndex.Value, cellFormatIndex);
            }
            return cellFormatIndex;
        }
        private static CellFormat CellFormatClone(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheBorder, Dictionary<uint, uint> cacheFill, Dictionary<uint, uint> cacheFont, Dictionary<uint, uint> cacheNumberFormat, CellFormat cellFormat)
        {
            CellFormat cellFormatClone = new CellFormat();
            cellFormatClone.ApplyAlignment = cellFormat.ApplyAlignment;
            cellFormatClone.ApplyBorder = cellFormat.ApplyBorder;
            cellFormatClone.ApplyFill = cellFormat.ApplyFill;
            cellFormatClone.ApplyFont = cellFormat.ApplyFont;
            cellFormatClone.ApplyNumberFormat = cellFormat.ApplyNumberFormat;
            cellFormatClone.ApplyProtection = cellFormat.ApplyProtection;
            cellFormatClone.PivotButton = cellFormat.PivotButton;
            cellFormatClone.QuotePrefix = cellFormat.QuotePrefix;
            GetBorder(workbookPartSource, workbookPartDestination, cacheBorder, cellFormat, cellFormatClone);
            GetFill(workbookPartSource, workbookPartDestination, cacheFill, cellFormat, cellFormatClone);
            GetFont(workbookPartSource, workbookPartDestination, cacheFont, cellFormat, cellFormatClone);
            GetNumberFormat(workbookPartSource, workbookPartDestination, cacheNumberFormat, cellFormat, cellFormatClone);
            if (cellFormat.Protection != null)
                cellFormatClone.Protection = (Protection)cellFormat.Protection.Clone();
            if (cellFormat.Alignment != null)
                cellFormatClone.Alignment = (Alignment)cellFormat.Alignment.Clone();
            return cellFormatClone;
        }
        private static void GetNumberFormat(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheNumberFormat, CellFormat cellFormat, CellFormat cellFormatClone)
        {
            uint numberFormatIndex = 0;
            if (cellFormat.NumberFormatId.Value != 0)
            {
                if (cacheNumberFormat.Keys.Contains(cellFormat.NumberFormatId.Value))
                {
                    numberFormatIndex = cacheNumberFormat[cellFormat.NumberFormatId.Value];
                }
                else
                {
                    NumberingFormat numberFormat = workbookPartSource.WorkbookStylesPart.Stylesheet.NumberingFormats.Descendants<NumberingFormat>().Where(nf => nf.NumberFormatId.Value == uint.Parse(cellFormat.NumberFormatId)).FirstOrDefault();
                    if (numberFormat != null)
                    {
                        if (workbookPartDestination.WorkbookStylesPart.Stylesheet.NumberingFormats != null)
                        {
                            if (workbookPartDestination.WorkbookStylesPart.Stylesheet.NumberingFormats.Descendants<NumberingFormat>().ToList().Count > int.Parse(cellFormat.NumberFormatId) &&
                            workbookPartDestination.WorkbookStylesPart.Stylesheet.NumberingFormats.Descendants<NumberingFormat>().ToList()[int.Parse(cellFormat.NumberFormatId)].OuterXml == numberFormat.OuterXml)
                            {
                                cellFormatClone.NumberFormatId = (uint)int.Parse(cellFormat.NumberFormatId);
                                return;
                            }
                            NumberingFormat nfclone = new NumberingFormat();
                            nfclone.FormatCode = numberFormat.FormatCode;
                            nfclone.NumberFormatId = workbookPartDestination.WorkbookStylesPart.Stylesheet.Descendants<NumberingFormat>().Max(nf => nf.NumberFormatId.Value) + 1;
                            workbookPartDestination.WorkbookStylesPart.Stylesheet.NumberingFormats.Append(nfclone);
                            numberFormatIndex = nfclone.NumberFormatId;
                            cacheNumberFormat.Add(cellFormat.NumberFormatId.Value, numberFormatIndex);
                        }
                    }
                    else
                    {
                        numberFormatIndex = cellFormat.NumberFormatId;
                    }
                }
                cellFormatClone.NumberFormatId = numberFormatIndex;
            }
            else
            {
                cellFormatClone.NumberFormatId = 0;
            }
        }
        private static void GetFont(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheFont, CellFormat cellFormat, CellFormat cellFormatClone)
        {
            uint fontIndex;
            if (cellFormat.FontId.Value != 0)
            {
                if (cacheFont.Keys.Contains(cellFormat.FontId.Value))
                {
                    fontIndex = cacheFont[cellFormat.FontId.Value];
                }
                else
                {
                    Font font = workbookPartSource.WorkbookStylesPart.Stylesheet.Fonts.Descendants<Font>().ToList()[int.Parse(cellFormat.FontId)];
                    if (workbookPartDestination.WorkbookStylesPart.Stylesheet.Fonts.Descendants<Font>().ToList().Count > int.Parse(cellFormat.FontId) &&
                   workbookPartDestination.WorkbookStylesPart.Stylesheet.Fonts.Descendants<Font>().ToList()[int.Parse(cellFormat.FontId)].OuterXml == font.OuterXml)
                    {
                        cellFormatClone.FontId = (uint)int.Parse(cellFormat.FontId);
                        return;
                    }
                    Font fontClone = new Font();
                    if (font.Bold != null)
                        fontClone.Bold = (Bold)font.Bold.Clone();
                    if (font.Color != null)
                        fontClone.Color = (Color)font.Color.Clone();
                    if (font.Condense != null)
                        fontClone.Condense = (Condense)font.Condense.Clone();
                    if (font.Extend != null)
                        fontClone.Extend = (Extend)font.Extend.Clone();
                    if (font.FontCharSet != null)
                        fontClone.FontCharSet = (FontCharSet)font.FontCharSet.Clone();
                    if (font.FontName != null)
                        fontClone.FontName = (FontName)font.FontName.Clone();
                    if (font.FontScheme != null)
                        fontClone.FontScheme = (FontScheme)font.FontScheme.Clone();
                    if (font.FontSize != null)
                        fontClone.FontSize = (FontSize)font.FontSize.Clone();
                    if (font.Italic != null)
                        fontClone.Italic = (Italic)font.Italic.Clone();
                    if (font.Outline != null)
                        fontClone.Outline = (Outline)font.Outline.Clone();
                    if (font.Shadow != null)
                        fontClone.Shadow = (Shadow)font.Shadow.Clone();
                    if (font.Strike != null)
                        fontClone.Strike = (Strike)font.Strike.Clone();
                    if (font.Underline != null)
                        fontClone.Underline = (Underline)font.Underline.Clone();
                    if (font.VerticalTextAlignment != null)
                        fontClone.VerticalTextAlignment = (VerticalTextAlignment)font.VerticalTextAlignment.Clone();
                    if (font.FontFamilyNumbering != null)
                        fontClone.FontFamilyNumbering = (FontFamilyNumbering)font.FontFamilyNumbering.Clone();
                    workbookPartDestination.WorkbookStylesPart.Stylesheet.Fonts.Append(fontClone);
                    fontIndex = (uint)workbookPartDestination.WorkbookStylesPart.Stylesheet.Fonts.Descendants<Font>().ToList().IndexOf(fontClone);
                    cacheFont.Add(cellFormat.FontId.Value, fontIndex);
                }
                cellFormatClone.FontId = fontIndex;
            }
            else
            {
                cellFormatClone.FontId = 0;
            }
        }
        private static void GetFill(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheFill, CellFormat cellFormat, CellFormat cellFormatClone)
        {
            uint fillIndex;
            if (cellFormat.FillId.Value != 0)
            {
                if (cacheFill.Keys.Contains(cellFormat.FillId.Value))
                {
                    fillIndex = cacheFill[cellFormat.FillId.Value];
                }
                else
                {
                    Fill fill = workbookPartSource.WorkbookStylesPart.Stylesheet.Fills.Descendants<Fill>().ToList()[int.Parse(cellFormat.FillId)];
                    if (workbookPartDestination.WorkbookStylesPart.Stylesheet.Fills.Descendants<Fill>().ToList().Count > int.Parse(cellFormat.FillId) &&
                      workbookPartDestination.WorkbookStylesPart.Stylesheet.Fills.Descendants<Fill>().ToList()[int.Parse(cellFormat.FillId)].OuterXml == fill.OuterXml)
                    {
                        cellFormatClone.FillId = (uint)int.Parse(cellFormat.FillId);
                        return;
                    }
                    Fill fillclone = new Fill();
                    if (fill.GradientFill != null)
                        fillclone.GradientFill = (GradientFill)fill.GradientFill.Clone();
                    if (fill.PatternFill != null)
                        fillclone.PatternFill = (PatternFill)fill.PatternFill.Clone();
                    workbookPartDestination.WorkbookStylesPart.Stylesheet.Fills.Append(fillclone);
                    fillIndex = (uint)workbookPartDestination.WorkbookStylesPart.Stylesheet.Fills.Descendants<Fill>().ToList().IndexOf(fillclone);
                    cacheFill.Add(cellFormat.FillId.Value, fillIndex);
                }
                cellFormatClone.FillId = fillIndex;
            }
            else
            {
                cellFormatClone.FillId = 0;
            }
        }
        private static void GetBorder(WorkbookPart workbookPartSource, WorkbookPart workbookPartDestination, Dictionary<uint, uint> cacheBorder, CellFormat cellFormat, CellFormat cellFormatClone)
        {
            uint borderIndex;
            if (cellFormat.BorderId.Value != 0)
            {
                if (cacheBorder.Keys.Contains(cellFormat.BorderId.Value))
                {
                    borderIndex = cacheBorder[cellFormat.BorderId.Value];
                }
                else
                {
                    Border border = workbookPartSource.WorkbookStylesPart.Stylesheet.Borders.Descendants<Border>().ToList()[int.Parse(cellFormat.BorderId)];
                    if (workbookPartDestination.WorkbookStylesPart.Stylesheet.Borders.Descendants<Border>().ToList().Count > int.Parse(cellFormat.BorderId) &&
                        workbookPartDestination.WorkbookStylesPart.Stylesheet.Borders.Descendants<Border>().ToList()[int.Parse(cellFormat.BorderId)].OuterXml == border.OuterXml)
                    {
                        cellFormatClone.BorderId = (uint)int.Parse(cellFormat.BorderId);
                        return;
                    }
                    Border borderclone = new Border();
                    if (border.StartBorder != null)
                        borderclone.StartBorder = (StartBorder)border.StartBorder.Clone();
                    if (border.EndBorder != null)
                        borderclone.EndBorder = (EndBorder)border.EndBorder.Clone();
                    if (border.LeftBorder != null)
                        borderclone.LeftBorder = (LeftBorder)border.LeftBorder.Clone();
                    if (border.RightBorder != null)
                        borderclone.RightBorder = (RightBorder)border.RightBorder.Clone();
                    if (border.TopBorder != null)
                        borderclone.TopBorder = (TopBorder)border.TopBorder.Clone();
                    if (border.BottomBorder != null)
                        borderclone.BottomBorder = (BottomBorder)border.BottomBorder.Clone();
                    if (border.DiagonalBorder != null)
                        borderclone.DiagonalBorder = (DiagonalBorder)border.DiagonalBorder.Clone();
                    if (border.VerticalBorder != null)
                        borderclone.VerticalBorder = (VerticalBorder)border.VerticalBorder.Clone();
                    if (border.HorizontalBorder != null)
                        borderclone.HorizontalBorder = (HorizontalBorder)border.HorizontalBorder.Clone();
                    workbookPartDestination.WorkbookStylesPart.Stylesheet.Borders.Append(borderclone);
                    borderIndex = (uint)workbookPartDestination.WorkbookStylesPart.Stylesheet.Borders.Descendants<Border>().ToList().IndexOf(borderclone);
                    cacheBorder.Add(cellFormat.BorderId.Value, borderIndex);
                }
                cellFormatClone.BorderId = borderIndex;
            }
            else
            {
                cellFormatClone.BorderId = 0;
            }
        }
        private static int InsertSharedStringItem_(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }
            int i = 0;
            
            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }
                i++;
            }
            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();
            return i;
        }
        private static void DeleteWorkSheet(WorkbookPart wbPart, string sheetToDelete)
        {
            string Sheetid = "";
            // Get the pivot Table Parts
            IEnumerable<PivotTableCacheDefinitionPart> pvtTableCacheParts = wbPart.PivotTableCacheDefinitionParts;
            Dictionary<PivotTableCacheDefinitionPart, string> pvtTableCacheDefinationPart = new Dictionary<PivotTableCacheDefinitionPart, string>();
            foreach (PivotTableCacheDefinitionPart Item in pvtTableCacheParts)
            {
                PivotCacheDefinition pvtCacheDef = Item.PivotCacheDefinition;
                //Check if this CacheSource is linked to SheetToDelete
                var pvtCahce = pvtCacheDef.Descendants<CacheSource>().Where(s => s.WorksheetSource.Sheet == sheetToDelete);
                if (pvtCahce.Count() > 0)
                {
                    pvtTableCacheDefinationPart.Add(Item, Item.ToString());
                }
            }
            foreach (var Item in pvtTableCacheDefinationPart)
            {
                wbPart.DeletePart(Item.Key);
            }
            //Get the SheetToDelete from workbook.xml
            Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetToDelete).FirstOrDefault();
            if (theSheet == null)
            {
                // The specified sheet doesn't exist.
            }
            //Store the SheetID for the reference
            Sheetid = theSheet.SheetId;
            // Remove the sheet reference from the workbook.
            WorksheetPart worksheetPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
            theSheet.Remove();
            // Delete the worksheet part.
            wbPart.DeletePart(worksheetPart);
            //Get the DefinedNames
            var definedNames = wbPart.Workbook.Descendants<DefinedNames>().FirstOrDefault();
            if (definedNames != null)
            {
                foreach (DefinedName Item in definedNames)
                {
                    // This condition checks to delete only those names which are part of Sheet in question
                    if (Item.Text.Contains(sheetToDelete + "!"))
                        Item.Remove();
                }
            }
            // Get the CalculationChainPart 
            //Note: An instance of this part type contains an ordered set of references to all cells in all worksheets in the 
            //workbook whose value is calculated from any formula
            CalculationChainPart calChainPart;
            calChainPart = wbPart.CalculationChainPart;
            if (calChainPart != null)
            {
                var calChainEntries = calChainPart.CalculationChain.Descendants<CalculationCell>().Where(c => c.SheetId == Sheetid);
                foreach (CalculationCell Item in calChainEntries)
                {
                    Item.Remove();
                }
                if (calChainPart.CalculationChain.Count() == 0)
                {
                    wbPart.DeletePart(calChainPart);
                }
            }
            // Save the workbook.
            wbPart.Workbook.Save();
        }
