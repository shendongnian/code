        private static string DataTableToJson(DataTable dataTable)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var rows = (from DataRow d in dataTable.Rows
                select dataTable.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => d[col])).ToList();
            rows.AddRange(from DataRow d in dataTable.Rows
                select dataTable.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => d[col]));
            return serializer.Serialize(rows);
        }
