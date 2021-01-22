            foreach (ForeignKey key in currentTable.ForeignKeys)
                {
                    foreach (Column column in key.Columns)
                    {
                        Console.WriteLine("Column: {0} is a foreign key to Table: {1}",column.Name,key.ReferencedTable);
                    }
                }
