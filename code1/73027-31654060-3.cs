    static void Main(string[] args)
    {
        Microsoft.Office.Interop.Excel.Application oExcel = ExcelInteropService.GetExcelInterop();
        foreach (AddIn addIn in oExcel.AddIns)
            {
                addIn.Installed = true;
            }
    }
