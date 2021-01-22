using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
//
//
//
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.TextFieldType = FieldType.Delimited;
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    string[] colFields = csvReader.ReadFields();
                    int columnCounter = 0;
                    foreach (string column in colFields)
                    {
                        if (columnCounter > 1023)
                        {
                            break; // the table has reached the maximum column size, either ignore the extra columns, or create additional linked tables (sounds like awful table design though).
                        }
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                        columnCounter++;
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        Array.Resize(ref fieldData, 1024);   //max number of columns is 1024 in SQL table, and we're not going through the trouble of making a Sparse table.
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return csvData;
        }
        /** <summary>
        * Gets the correct SqlDBType for a given .NET type. Useful for working with SQL.
        * </summary>
        * <param name="type">The .Net Type used to find the SqlDBType.</param>
        * <returns>The correct SqlDbType for the .Net type passed in.</returns>
        */
        public static SqlDbType GetSqlDBTypeFromType(Type type)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(DbType));
            DbType dbType = (DbType)tc.ConvertFrom(type.Name);
            // A cheat, but the parameter class knows how to map between DbType and SqlDBType.
            SqlParameter param = new SqlParameter();
            param.DbType = dbType;
            return param.SqlDbType; // The parameter class did the conversion for us!!
        }
        /**
        * <summary>
        * The method gets the SQL type name for use in SQL Statements such as CREATE TABLE
        * </summary>
        * <param name="dbType">The SqlDbType to get the type name for</param>
        * <param name="size">The size where applicable e.g. to create a nchar(n) type where n is the size passed in.</param>
        * <returns>A string of the SQL compatible type for use in SQL Statements</returns>
        */
        public static string GetSqlServerTypeName(SqlDbType dbType, int size)
        {
            // Conversions according to: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
            bool max = (size == int.MaxValue || size == -1) ? true : false;
            string returnVal = "";
            if (max)
            {
                returnVal = Enum.GetName(typeof(SqlDbType), dbType) + " (max)";
            }
            else if (size > 0)
            {
                returnVal = string.Format(Enum.GetName(typeof(SqlDbType), dbType) + " ({0})", size);
            }
            else
            {
                returnVal = Enum.GetName(typeof(SqlDbType), dbType);
            }
            return returnVal;
        }
        /**
         * <summary>
        * Genenerates a SQL compatible CREATE TABLE statement based on a schema obtained from
        * a SqlDataTable.
        * </summary>
        * <param name="table">The name of the table to be created.</param>
        * <returns>The CREATE TABLE... Statement for the given data table.</returns>
        */
        public static string GetCreateTableStatement(DataTable table)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("CREATE TABLE [{0}] (", table.TableName));
            int primaryCol = 0;
            foreach (DataColumn col in table.Columns)
            {
                SqlDbType dbType = GetSqlDBTypeFromType(col.DataType);
                builder.Append("[");
                builder.Append(col.ColumnName);
                builder.Append("]");
                builder.Append(" ");
                builder.Append(GetSqlServerTypeName(dbType, col.MaxLength));
                //if on first column, assume it's a "PRIMARY KEY" (for now)
                if(primaryCol == 0)
                {
                    builder.Append(" PRIMARY KEY");
                }
                builder.Append(", ");
                primaryCol++;
            }
            if (table.Columns.Count > 0) builder.Length = builder.Length - 2;
            builder.Append(")");
            return builder.ToString();
        }
        /**
         * <summary>
        * Genenerates a SQL compatible CREATE TABLE statement based on a schema obtained from
        * a SqlDataTable.
        * </summary>
        * <param name="dtable">The name of the table to be created.</param>
        * <param name="conn">The SQL Connection to the database that the table will be created in.</param>
         */
        public static void CreateFromDataTable(DataTable dTable, SqlConnection conn)
        {
            bool openedHere = false;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                openedHere = true;
            }
            SqlCommand cmd;
            string createSql = GetCreateTableStatement(dTable);
            Console.WriteLine(createSql);
            cmd = new SqlCommand(createSql, conn);
            Console.WriteLine(cmd.ExecuteNonQuery());
            if (openedHere)
            {
                conn.Close();
            }
        }
