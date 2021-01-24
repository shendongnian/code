    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    class LooperMain
    {
        static void Main()
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            string strReportName = @"C:\Users\v.doynov\Desktop\123.xlsx";
            Excel.Workbook wkb =  Open(excel, strReportName);
            SetZoom(10, wkb, excel);
        }
    
        public static void SetZoom(int zoomLevel, 
                                  Excel.Workbook wb, 
                                  Excel.Application excelInstance)
        {
            foreach (Excel.Worksheet ws in wb.Worksheets)
            {
                ws.Activate();
                excelInstance.ActiveWindow.Zoom = zoomLevel;
            }
        }
    
        public static Excel.Workbook Open(Excel.Application excelInstance, 
                                   string fileName, bool readOnly = false, 
                                   bool editable = true, bool updateLinks = true)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly);                                  
            return book;
        }
    }
