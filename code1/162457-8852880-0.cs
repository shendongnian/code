    using System;  
    using System.Data;  
    using System.IO;  
    using System.Runtime.InteropServices;  
    using Excel = Microsoft.Office.Interop.Excel; 
    public class clsExcelWriter : IDisposable  
    {  
        private Excel.Application oExcel;  
        private Excel._Workbook oBook;  
        private Excel._Worksheet oSheet;  
        // Used to store the name of the current file
        public string FileName
        {
            get;
            private set;
        }
        public clsExcelWriter(string filename)
        {
            // Initialize Excel
            oExcel = new Excel.Application();
            if (!File.Exists(filename))
            {
                // Create a new one?
            }
            else
            {
                oBook = (Excel._Workbook)oExcel.Workbooks.Open(filename);
                oSheet = (Excel._Worksheet)oBook.ActiveSheet;
            }
            this.FileName = filename;
            // Supress any alerts
            oExcel.DisplayAlerts = false;
        }
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;
            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
        public void Dispose()
        {
            // Lets make sure we release those COM objects!
            if (oExcel != null)
            {
                Marshal.FinalReleaseComObject(oSheet);
                oBook.Close();
                Marshal.FinalReleaseComObject(oBook);
                oExcel.Quit();
                Marshal.FinalReleaseComObject(oExcel);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public static DataSet OpenFile(string filename)
        {
            DataSet ds = new DataSet();
            using (clsExcelWriter xl = new clsExcelWriter(filename))
            {
                // Iterate through each worksheet
                foreach (Excel._Worksheet sheet in xl.oBook.Worksheets)
                {
                    // Create a new table using the sheets name
                    DataTable dt = new DataTable(sheet.Name);
                    // Get the first row (where the headers should be located)
                    object[,] xlValues = (object[,])sheet.get_Range("A1", xl.GetExcelColumnName(sheet.UsedRange.Columns.Count) + 1).Value;
                    // Iterate through the values to add new DataColumns to the DataTable
                    for (int i = 0; i < xlValues.GetLength(1); i++)
                    {
                        dt.Columns.Add(new DataColumn(xlValues[1, i + 1].ToString()));
                    }
                    // Now get the rest of the rows
                    xlValues = (object[,])sheet.get_Range("A2", xl.GetExcelColumnName(sheet.UsedRange.Columns.Count) + sheet.UsedRange.Rows.Count).Value;
                    for (int row = 0; row < xlValues.GetLength(0); row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int col = 0; col < xlValues.GetLength(1); col++)
                        {
                            // xlValues array starts from 1, NOT 0 (just to confuse yee)
                            dr[dt.Columns[col].ColumnName] = xlValues[row + 1, col + 1];
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
            }
            // Your DataSet should now be filled! :)
            return ds;
        }
    }
}
