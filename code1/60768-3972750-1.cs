    using System.Diagnostics;
    using XL = Microsoft.Office.Interop.Excel;
     
    public static class WorkbookExtensions
    {
        [DebuggerNonUserCode]
        public static bool TryGetWorksheet(this XL.Workbook wb, string worksheetName, out XL.Worksheet retrievedWorksheet)
        {
            bool exists = false;
            retrievedWorksheet = null;
     
            try
            {
                retrievedWorksheet = GetWorksheet(wb, worksheetName);
                exists = retrievedWorksheet != null;
            }
            catch(COMException)
            {
                exists = false;
            }
     
            return exists;
        }
     
        [DebuggerNonUserCode]
        public static XL.Worksheet GetWorksheet(this XL.Workbook wb, string worksheetName)
        {
            return wb.Worksheets.get_Item(worksheetName) as XL.Worksheet;
        }
    }
