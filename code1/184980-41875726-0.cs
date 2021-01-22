        public static bool CheckIfTableExists(this DbConnection connection, string tableName) //connection = ((DbContext) _context).Database.Connection;
        {
            if (connection == null)
                throw new ArgumentException(nameof(connection));
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            var tableInfoOnTables = connection //0
                .GetSchema("Tables")
                .Columns
                .Cast<DataColumn>()
                .Select(x => x.ColumnName?.ToLowerInvariant() ?? "")
                .ToList();
            var tableNameColumnIndex = tableInfoOnTables.FindIndex(x => x.Contains("table".ToLowerInvariant()) && x.Contains("name".ToLowerInvariant())); //order
            tableNameColumnIndex = tableNameColumnIndex == -1 ? tableInfoOnTables.FindIndex(x => x.Contains("table".ToLowerInvariant())) : tableNameColumnIndex; //order
            tableNameColumnIndex = tableNameColumnIndex == -1 ? tableInfoOnTables.FindIndex(x => x.Contains("name".ToLowerInvariant())) : tableNameColumnIndex; //order
            if (tableNameColumnIndex == -1)
                throw new ApplicationException("Failed to spot which column holds the names of the tables in the dictionary-table of the DB");
            var constraints = new string[tableNameColumnIndex + 1];
            constraints[tableNameColumnIndex] = tableName;
            return connection.GetSchema("Tables", constraints)?.Rows.Count > 0;
        }
        //0 different databases have different number of columns and different names assigned to them
        //
        //     SCHEMA,TABLENAME,TYPE -> oracle
        //     table_catalog,table_schema,table_name,table_type -> mssqlserver
        //
        //  we thus need to figure out which column represents the tablename and target that one
