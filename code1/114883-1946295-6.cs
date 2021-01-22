    Excel.Workbook myWorkbook = ...;
    
    if (!myWorkbook.HasPassword)
    {
       excelWorkbook.Application.DisplayAlerts = false;
       excelWorkbook.SaveAs(
            excelWorkbook.Name,
            Type.Missing,
            "My Password",
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Type.Missing,
            Type.Missing)
    }
