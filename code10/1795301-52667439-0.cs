    public byte[] createExcelSpreadsheet(List<BarBillList> barBillExport)
    {
        DateTime today = DateTime.Today;
        using (MemoryStream ms = new MemoryStream())
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                //Creating the initial document
                ...
    
                //Styling the doucment
                ...
    
                //Adding width to the columns
                ...
    
                //Creating the worksheet part to add the data to
                ...
    
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
    
                //Creating the first Header Row
                ...
    
                //Appending the data into their respective columns 
                foreach (var ent in barBillExport)
                {
                    ...
                }
    
                worksheetPart.Worksheet.Save();
                document.Close();
                return ms.ToArray();
            }
        }
    }
