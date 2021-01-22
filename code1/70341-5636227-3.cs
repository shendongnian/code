    /// <summary>
        /// Genenerates a SQL CE compatible CREATE TABLE statement based on a schema obtained from
        /// a SqlDataReader or a SqlCeDataReader.
        /// </summary>
        /// <param name="tableName">The name of the table to be created.</param>
        /// <param name="schema">The schema returned from reader.GetSchemaTable().</param>
        /// <returns>The CREATE TABLE... Statement for the given schema.</returns>
        public static string GetCreateTableStatement(DataTable table)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("CREATE TABLE [{0}] (", table.TableName));
            foreach (DataColumn col in table.Columns)
            {
                SqlDbType dbType = GetSqlDBTypeFromType(col.DataType);
                builder.Append("[");
                builder.Append(col.ColumnName);
                builder.Append("]");
                builder.Append(" ");
                builder.Append(GetSqlServerCETypeName(dbType, col.MaxLength));
                builder.Append(", ");
            }
            if (table.Columns.Count > 0) builder.Length = builder.Length - 2;
            builder.Append(")");
            return builder.ToString();
        }
