                DataTable schemaTable = sqlReader.GetSchemaTable();
                foreach (DataRow row in schemaTable.Rows)
                {
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        MessageBox.Show (string.Format("{0} = {1}", column.ColumnName, row[column]));
                    }
                }
