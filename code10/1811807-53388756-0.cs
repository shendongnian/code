     using (SpreadsheetDocument xl = SpreadsheetDocument.Open(targetFile, true))
            {
                WorkbookPart workbookPart = xl.WorkbookPart;
                foreach (WorksheetPart sheet in workbookPart.WorksheetParts)
                {
                    List<TableDefinitionPart> TableDefinitionPartToDelete = new List<TableDefinitionPart>();
                    var TableParts = sheet.Worksheet.WorksheetPart.Worksheet.Descendants<TablePart>();
                    
                    List<TablePart> TablePartToDelete = new List<TablePart>();
                    foreach (var Item in TableParts)
                    {
                        TablePartToDelete.Add(Item);
                    }
                    foreach (var tp in TablePartToDelete)
                    {
                        tp.Remove();
                    }
                    
                    foreach (TableDefinitionPart Item in sheet.TableDefinitionParts)
                    {
                        TableDefinitionPartToDelete.Add(Item);
                    }
                    foreach (TableDefinitionPart Item in TableDefinitionPartToDelete)
                    {               
                        sheet.DeletePart(Item);
                    }
                }
                
                xl.Close();
            }
