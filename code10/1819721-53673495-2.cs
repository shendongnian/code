    //Make sure you add these two references. 
    using Microsoft.Office.Interop
    using Excel = Microsoft.Office.Interop.Excel
    
    //Call this before your insert
    static void FileOpen() {
        string path = "Path.xlsx"
        var excel = new Excel.Application
        excel.Visible=True
    
        Excel.Workbooks books = excel.Workbooks;
        Excel.Workbook sheet = books.Open(path);
    }
