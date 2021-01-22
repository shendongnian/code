                    foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        ColumnName = column.ColumnName;
                        ColumnData = row[column].ToString();
                    }
                }
