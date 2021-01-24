    using System;
    using System.Collections.Generic;
    // Add nuget reference to smartsheet-csharp-sdk (https://www.nuget.org/packages/smartsheet-csharp-sdk/)
    using Smartsheet.Api;
    using Smartsheet.Api.Models;
    using System.Linq;
    namespace sdk_csharp_sample
    {
        class Program
        {
            static Dictionary<string, long> columnMap = new Dictionary<string, long>();
            static Dictionary<string, long> columnMapPMO = new Dictionary<string, long>();
            static void Main(string[] args)
            {
                // Initialize client
                SmartsheetClient ss = new SmartsheetBuilder()
                    .SetHttpClient(new RetryHttpClient())
                    .Build();
                heet insert = ss.SheetResources.GetSheet(...148L, null, null, null, null, null, null, null);
                Sheet pmosheet = ss.SheetResources.GetSheet(...556L, null, null, null, null, null, null, null);
                // Build column map for later reference
                foreach (Column column in insert.Columns)
                    columnMap.Add(column.Title, (long)column.Id);
                foreach (Column column in pmosheet.Columns)
                    columnMapPMO.Add(column.Title, (long)column.Id);
                IList<Row> rowsToCompare = pmosheet.Rows;
                IList<Row> rowsToMove = insert.Rows;
                foreach (Row innerrow in rowsToMove)
                {
                    Cell MainTitle = getCellByColumnName(innerrow, "Title");
                    foreach (Row row in rowsToCompare)
                    {
                        Cell PMOPName = getPMOCellByColumnName(row, "Project Name");
                        if (PMOPName.DisplayValue == MainTitle.DisplayValue)
                        {
                            Console.WriteLine("Yes");
                            break;
                        }
                        else
                            Console.WriteLine("No");
                    }
                }
            }
            static Cell getCellByColumnName(Row row, string columnName)
            {
                return row.Cells.FirstOrDefault(cell => cell.ColumnId ==
                columnMap[columnName]);
            }
            static Cell getPMOCellByColumnName(Row row, string columnName)
            {
                return row.Cells.FirstOrDefault(cell => cell.ColumnId ==
                columnMapPMO[columnName]);
            }
        }
    }
