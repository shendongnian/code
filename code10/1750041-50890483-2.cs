    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> columnHeaders = excel.Worksheet.Select(x => (string)x[0]).ToList();
                columnHeaders = columnHeaders.Distinct().ToList();
                DataTable pivotTable = new DataTable();
                foreach (string columnHeader in columnHeaders)
                {
                    if(columnHeader != "")
                       pivotTable.Columns.Add(columnHeader, typeof(string));
                }
                DataRow newRow = null;
                foreach (var row in excel.Worksheet)
                {
                    if ((string)row[0] == "Program #")
                    {
                        newRow = pivotTable.Rows.Add();
                    }
                    if((row[0] != null) && ((string)row[0] != ""))
                       newRow[(string)row[0]] = (row[1] == null) ? "" : row[1];  
                }
            }
        }
    }
