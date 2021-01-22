        /// <summary>
        /// Gets the correct SqlDBType for a given .NET type. Useful for working with SQL CE.
        /// </summary>
        /// <param name="type">The .Net Type used to find the SqlDBType.</param>
        /// <returns>The correct SqlDbType for the .Net type passed in.</returns>
        public static SqlDbType GetSqlDBTypeFromType(Type type)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(DbType));
            if (/*tc.CanConvertFrom(type)*/ true)
            {
                DbType dbType = (DbType)tc.ConvertFrom(type.Name);
                // A cheat, but the parameter class knows how to map between DbType and SqlDBType.
                SqlCeParameter param = new SqlCeParameter();
                param.DbType = dbType;
                return param.SqlDbType; // The parameter class did the conversion for us!!
            }
            else
            {
                throw new Exception("Cannot get SqlDbType from: " + type.Name);
            }
        }
            /// <summary>
        /// The method gets the SQL CE type name for use in SQL Statements such as CREATE TABLE
        /// </summary>
        /// <param name="dbType">The SqlDbType to get the type name for</param>
        /// <param name="size">The size where applicable e.g. to create a nchar(n) type where n is the size passed in.</param>
        /// <returns>The SQL CE compatible type for use in SQL Statements</returns>
        public static string GetSqlServerCETypeName(SqlDbType dbType, int size)
        {
            // Conversions according to: http://msdn.microsoft.com/en-us/library/ms173018.aspx
            bool max = (size == int.MaxValue) ? true : false;
            bool over4k = (size > 4000) ? true : false;
            if (size>0)
            {
                return string.Format(Enum.GetName(typeof(SqlDbType), dbType)+" ({0})", size); 
            }
            else
            {
                return Enum.GetName(typeof(SqlDbType), dbType);
            }
        }
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
            public static void CreateFromDataset(DataSet set, SqlCeConnection conn)
        {
            conn.Open();
            SqlCeCommand cmd;
            foreach (DataTable table in set.Tables)
            {
                string createSql = copyDB.GetCreateTableStatement(table);
                Console.WriteLine(createSql);
                cmd = new SqlCeCommand(createSql, conn);
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
            conn.Close();
        }
    }
