    using System;
    using OfficeOpenXml;
    using System.Data;
    using System.Linq;
    namespace excelReadWrite
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create Excel Package and set path
                ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"D:\IDG\test2.xlsx"));
                DataTable dt = new DataTable();
                dt = ToDataTable(package);
            }
            public static DataTable ToDataTable(ExcelPackage package)
            {
                // Sets worksheet to first sheet found
                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                DataTable table = new DataTable();
                // Iterate through first row and set Datatable columns
                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                {
                    table.Columns.Add(firstRowCell.Text);
                }
                // Iterate through all rows and set values
                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                {
                    var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                   var newRow = table.NewRow();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Value;
                    }
                    // Set value of every row processed last column to 1
                    workSheet.Cells[rowNumber, workSheet.Dimension.End.Column].Value = 1;
                    table.Rows.Add(newRow);
                }
                // Save excel file
                package.Save();
                return table;
            }
    
        }
    }
