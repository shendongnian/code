                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = true,
                    ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                DataTableCollection tables = result.Tables;
                for (int i = 0; i < tables.Count; i++)
                {
                    Console.WriteLine(tables[i].TableName);
                    //here I can work with current table
                    for (int j = 0; j < tables[i].Columns.Count; j++)
                    {
                        Console.WriteLine(tables[i].Columns[j].ColumnName);
                    }
                }
