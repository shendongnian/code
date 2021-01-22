     public static void DeleteRowsFromDataTable(DataTable dataTable, string columnName, string columnValue)
            {
                IEnumerable<DataRow> dataRows = (from t in dataTable.AsEnumerable()
                                                 where t.Field<string>(columnName) == columnValue
                                                 select t);
                foreach (DataRow row in dataRows)
                    dataTable.Rows.Remove(row);
            }
