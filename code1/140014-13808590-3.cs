    // Open that xml file with excel
    DataSource = excel2.Workbooks.Open(FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    // Get items from xml file
    DataSheet = DataSource.Worksheets.get_Item(1);
    // Create another Excel app as object
    Object xl_app;
    xl_app = GetObj(1, "Excel.Application");
    Excel.Application xlApp = (Excel.Application)xl_app;
    // Set previous Excel app (Xml) as ReportPage
    Excel.Application ReportPage = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    // Copy items from ReportPage(Xml) to current Excel object
    Excel.Workbook Copy_To_Excel = ReportPage.ActiveWorkbook;
