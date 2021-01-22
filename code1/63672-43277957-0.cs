    using System;
    using System.IO;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace ExporExcel
    {
        class Program
        {
            static void Main(string[] args)
            {
                SqlConnection con = new SqlConnection("Data Source=WINCTRL-KJ8RKFO;Initial Catalog=excel;Integrated Security=True");
    
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Employee",con);
                sda.Fill(dt);
                ExportToExcel(dt);
            }
    
            public static void ExportToExcel(DataTable dtReport, string ExcelFilePath = null)
            {
                
                    int ColumnsCount;
    
                    if (dtReport == null || (ColumnsCount = dtReport.Columns.Count) == 0)
    
                        throw new Exception("ExportToExcel: Null or empty input table!\n");
    
                   
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Excel.Workbooks.Add();
    
                    
                    Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;
    
                    object[] Header = new object[ColumnsCount];
                                 
                        for (int i = 0; i < ColumnsCount; i++)
                        Header[i] = dtReport.Columns[i].ColumnName;
    
         Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]),
         (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                               
                    int RowsCount = dtReport.Rows.Count;
                    object[,] Cells = new object[RowsCount, ColumnsCount];
    
                    for (int j = 0; j < RowsCount; j++)
                        for (int i = 0; i < ColumnsCount; i++)
                                    Cells[j, i] = dtReport.Rows[j][i];
    
                    Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;
                    Excel.Visible = true;
            }
          }
       }
