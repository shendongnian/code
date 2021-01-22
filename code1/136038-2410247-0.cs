    using System;
    using SpreadsheetGear;
    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fileName = @"D:\one.xls";
                IWorkbook wbook = SpreadsheetGear.Factory.GetWorkbook(fileName);
                IWorksheet wsheet = wbook.ActiveWorksheet;
                wsheet.Name = "Customers";
                System.Data.DataTable dt = new System.Data.DataTable("test");
                dt.Columns.Add("col1");
                dt.Columns.Add("col2");
                dt.Columns.Add("col3");
                dt.Rows.Add(new object[] { "one", "one", "one" });
                dt.Rows.Add(new object[] { "two", "two", "two" });
                dt.Rows.Add(new object[] { "three", "three", "three" });
                wsheet.Cells[0, 0, dt.Rows.Count - 1, dt.Columns.Count - 1].CopyFromDataTable(dt, SpreadsheetGear.Data.SetDataFlags.None);
                wsheet.UsedRange.EntireColumn.AutoFit();
                wbook.Save();
            }
        }
    }
