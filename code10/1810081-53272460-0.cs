    using(Microsoft.Office.Interop.Excel.Application xlTemp = new 
    Microsoft.Office.Interop.Excel.Application())
    {
       Workbook workbook = xlTemp.Workbooks.Open(excelTemplate);
       xlTemp.DisplayAlerts = false;
    
       // Poke through individual sheets, get some info from them
    
       workbook.Close();
    }
