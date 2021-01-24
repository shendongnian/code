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
                string[] columnHeaders = excel.Worksheet.Select(x => (string)x[0]).Distinct().ToArray();
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
                    if((string)row[0] != "")
                       newRow[(string)row[0]] = row[1];  
                }
            }
        }
    }
