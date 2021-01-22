    Microsoft.Office.Interop.Excel.Sheets sheets = newWorkbook.ExcelSheets;
    if ( sheets != null )
    {
         foreach ( Microsoft.Office.Interop.Excel.Worksheet sheet in sheets )
         {
              // Do Stuff
         }
    }
