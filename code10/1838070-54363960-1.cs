    ----------
    // Code sample.
    private void Download()
    {
        DataTable datatable=yourDatatable;// callStore Procedure to fetch  DataTable
        ExcelFile csvFile = new ExcelFile();//GemBox.Spreadsheet ExcelFile  
        ExcelWorksheet ws = csvFile.Worksheets.Add("YourWorkSheetName");
        
        if (ws != null)
        {
            ws.InsertDataTable(datatable, 0, 0, true);
            // Use MemoryStream to save or to send it to client as response.
        }
    }
    
    ----------
