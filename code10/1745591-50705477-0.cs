            myDS.Tables
                .OfType<DataTable>()
                .Where(table => new string[] { "MyTable1" , "MyTable2" }.Contains(table.TableName))
                .ToList().ForEach(table =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Table Name = " + table.TableName);
                });
