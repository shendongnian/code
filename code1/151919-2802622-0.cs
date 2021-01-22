    Microsoft.Office.Interop.Excel.Application xlApp = new Application();
    Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Open("excelTemplateFile.xls",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
  
