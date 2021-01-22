        /// <summary>
        /// Genenerates a SQL CE compatible CREATE TABLE statement based on a schema obtained from
        /// a SqlDataReader or a SqlCeDataReader.
        /// </summary>
        /// <param name="tableName">The name of the table to be created.</param>
        /// <param name="schema">The schema returned from reader.GetSchemaTable().</param>
        /// <returns>The CREATE TABLE... Statement for the given schema.</returns>
        public static string GetCreateTableStatement(string tableName, DataTable schema)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("CREATE TABLE [{0}] (\n", tableName));
    
            foreach (DataRow row in schema.Rows)
            {
                string typeName = row["DataType"].ToString();
                Type type = Type.GetType(typeName);
    
                string name = (string)row["ColumnName"];
                int size = (int)row["ColumnSize"];
    
                SqlDbType dbType = GetSqlDBTypeFromType(type);
    
                builder.Append(name);
                builder.Append(" ");
                builder.Append(GetSqlServerCETypeName(dbType, size));
                builder.Append(", ");
            }
    
            if (schema.Rows.Count > 0) builder.Length = builder.Length - 2;
    
            builder.Append("\n)");
            return builder.ToString();
        }
