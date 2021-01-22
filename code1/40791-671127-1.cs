    using System.IO;
    using System.Xml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml;
    // Database object
            DataClassesDataContext db = new DataClassesDataContext();
    
            // Make a copy of the template file.
            File.Copy(@"C:\inetpub\wwwroot\project.Web\Clients\Handlers\oxml-tpl\livreurs.xlsx", @"C:\inetpub\wwwroot\project.Web\Clients\Handlers\oxml-tpl\generated.xlsx", true);
            
            // Open the copied template workbook. 
            using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open(@"C:\inetpub\wwwroot\project.Web\Clients\Handlers\oxml-tpl\generated.xlsx", true))
            {
                // Access the main Workbook part, which contains all references.
                WorkbookPart workbookPart = myWorkbook.WorkbookPart;
                
                // Get the first worksheet. 
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.ElementAt(2);
                
                // The SheetData object will contain all the data.
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                
                // Begining Row pointer                       
                int index = 2;
                
                // Database results
                var query = from t in db.Clients select t;
    
                // For each item in the database, add a Row to SheetData.
                foreach (var item in query)
                {
                    // Cell related variable
                    string Nom = item.Nom;
                    
                    // New Row
                    Row row = new Row();
                    row.RowIndex = (UInt32)index;
    
                    // New Cell
                    Cell cell = new Cell();
                    cell.DataType = CellValues.InlineString;
                    // Column A1, 2, 3 ... and so on
                    cell.CellReference = "A"+index;
    
                    // Create Text object
                    Text t = new Text();
                    t.Text = Nom;
    
                    // Append Text to InlineString object
                    InlineString inlineString = new InlineString();
                    inlineString.AppendChild(t);
    
                    // Append InlineString to Cell
                    cell.AppendChild(inlineString);
    
                    // Append Cell to Row
                    row.AppendChild(cell);
    
                    // Append Row to SheetData
                    sheetData.AppendChild(row);
                    
                    // increase row pointer
                    index++;                
                                    
                }
    
                // save
                worksheetPart.Worksheet.Save();
    
            }
