    using System;
    using Microsoft.Office.Interop.Excel;
    
    static class ExcelUtility
    {
        public static void WriteArray<T>(this _Worksheet sheet, int startRow, int startColumn, T[,] array)
        {
            var row = array.GetLength(0);
            var col = array.GetLength(1);
            Range c1 = (Range) sheet.Cells[startRow, startColumn];
            Range c2 = (Range) sheet.Cells[startRow + row - 1, startColumn + col - 1];
            Range range = sheet.Range[c1, c2];
            range.Value = array;
        }
    
        public static bool SaveToExcel<T>(T[,] data, string path)
        {
            try
            {
                //Start Excel and get Application object.
                var oXl = new Application {Visible = false};
    
                //Get a new workbook.
                var oWb = (_Workbook) (oXl.Workbooks.Add(""));
                var oSheet = (_Worksheet) oWb.ActiveSheet;
                //oSheet.WriteArray(1, 1, bufferData1);
    
                oSheet.WriteArray(1, 1, data);
    
                oXl.Visible = false;
                oXl.UserControl = false;
                oWb.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing,
                    Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oWb.Close(false);
                oXl.Quit();
            }
            catch (Exception e)
            {
                return false;
            }
    
            return true;
        }
    }
