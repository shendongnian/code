    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Ds2Xlsx
    {
        public class Ds2ExcelEngine
        {
            public static void CreateExcel(
                DataSet ds,
                string path,
                OfficeOpenXml.Table.TableStyles tableStyle = OfficeOpenXml.Table.TableStyles.Light9,
                bool autofitColumns = true)
            {
                if (ds != null)
                {
                    using (ExcelPackage ep = new ExcelPackage())
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            AddTableWorksheet(tableStyle, autofitColumns, ep, dt);
                        }
                        ep.SaveAs(new System.IO.FileInfo(path));
                    }
                }
            }
            private static void AddTableWorksheet(OfficeOpenXml.Table.TableStyles tableStyle, bool autofitColumns, ExcelPackage ep, DataTable dt)
            {
                ExcelWorksheet ew = ep.Workbook.Worksheets.Add(dt.TableName);
                int row = 1;
                int column = 1;
                foreach (DataColumn dc in dt.Columns)
                {
                    ew.Cells[row, column].Value = dc.Caption;
                    column++;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    column = 1;
                    row++;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ew.Cells[row, column].Value = dr[dc];
                        column++;
                    }
                }
                column = 1;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(DateTime))
                    {
                        ew.Cells[1, column, row, column].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                    }
                    column++;
                }
                var excelTable = ew.Tables.Add(new ExcelAddressBase(1, 1, row, column - 1), $"tbl_{ dt.TableName }");
                excelTable.TableStyle = tableStyle;
                if (autofitColumns)
                {
                    ew.Cells[ew.Dimension.Address].AutoFitColumns();
                }
            }
        }
    }
