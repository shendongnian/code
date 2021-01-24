    String pathToYourExcelFile = @"C:\Folder\ExcelFile.xlsx";
    using (SpreadsheetDocument document = SpreadsheetDocument.Open(pathToYourExcelFile, true))
    {
        WorkbookPart workbook =  document.WorkbookPart;                
        WorksheetPart firstWorksheet = document.WorkbookPart.WorksheetParts.FirstOrDefault();
        SharedStringTablePart stringTable = workbook.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();                              
        IEnumerable<Row> rows = firstWorksheet.Worksheet.GetFirstChild<SheetData>().Elements<Row>();
        Row firstRow = rows.FirstOrDefault();
                        
        foreach (Cell cell in firstRow.Elements<Cell>())
        {                    
            foreach (CellValue cellValue in cell.Elements<CellValue>())
            {   
                IEnumerable<SharedStringItem> sharedStrings = 
                    stringTable.SharedStringTable.Elements<SharedStringItem>()
                        .Where((o, i) => i == Convert.ToInt32(cellValue.InnerText));
                                                                                                
                foreach (SharedStringItem sharedString in sharedStrings)
                { 
                    IEnumerable<Run> runs = sharedString.Elements<Run>();
                    if (runs.Count() > 0)
                    {                                
                        foreach (Run run in runs)
                        {
                            if (run.InnerText == "RED")
                            {
                                RunProperties properties = run.RunProperties ?? new RunProperties();
                                Color color = properties.Elements<Color>().FirstOrDefault();
                                if (color != null)
                                {
                                    properties.RemoveChild<Color>(color);
                                }
                                                                        
                                properties.Append(new Color { Rgb = "FFFF0000" }) ;
                            }
                        }
                    }
                    else
                    {       
                        // No Runs, only text; create a Run.                                                     
                        Text text = new Text(sharedString.InnerText);                                
                        sharedString.RemoveAllChildren();
                        Run run = new Run();
                        run.Append(text);
                        run.RunProperties = new RunProperties();
                        run.RunProperties.Append(new Color { Rgb = "FFFF0000" }) ;
                        sharedString.Append(run);
                    }
                }
            }
        }
        document.Save();
