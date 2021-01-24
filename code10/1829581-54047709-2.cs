        public static void AssignValuesToPKTableTypeParameter(DbParameter parameter, ICollection<int> primaryKeys)
        {
            // Exceptions are handled by the caller
            var sqlParameter = parameter as SqlParameter;
            if (sqlParameter != null && sqlParameter.SqlDbType == SqlDbType.Structured)
            {
                // The type name may look like DatabaseName.dbo.PrimaryKeyType,
                // so remove the database name if it is present
                var parts = sqlParameter.TypeName.Split('.');
                if (parts.Length == 3)
                {
                    sqlParameter.TypeName = parts[1] + "." + parts[2];
                }
            }
            if (primaryKeys == null)
            {
                primaryKeys = new List<int>();
            }
            var table = new DataTable();
            table.Columns.Add("Value", typeof(int));
            foreach (var wPrimaryKey in primaryKeys)
            {
                table.Rows.Add(wPrimaryKey);
            }
            parameter.Value = table;
        }
