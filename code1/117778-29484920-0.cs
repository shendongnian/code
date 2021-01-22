    public static Workbook openExternalWorkBook(String fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();            
            excel.Visible = false;
            return excel.Workbooks.Open(fileName, false);
        }
