    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Text.RegularExpressions;
    
    namespace App.Sql.TableManagement
    {
    
        /// <summary>
        /// Struct stores the schema information for a sql server table column
        /// </summary>
        public struct SqlTableColumnSchema
        {
            public string ColumnName;
            public string DataType;
            public int MaximumLength;
        }
    
        /// <summary>
        /// Class is responsible for synchronizing a SQL Server table with a .net DataTable.
        /// </summary>
        public class SqlTableManager
        {
            private DataTable m_TableSchema;
            private string m_SqlConnectionString;
            private string m_SqlTableName;
    
            private Dictionary<string, SqlTableColumnSchema> m_SqlTableColumns = new Dictionary<string, SqlTableColumnSchema>();
    
            /// <summary>
            /// Class contructor
            /// </summary>
            /// <param name="schemaFile">The xml file that contains the table schema</param>
            /// <param name="sqlConnectionString">Connection string to the destination database</param>
            /// <param name="sqlTableName">The name of the destination table if this value is null then the table in xml file will be used.</param>
            public SqlTableManager(DataTable table, string sqlConnectionString)
            {
                m_SqlConnectionString = sqlConnectionString;
                m_SqlTableName = table.TableName.Replace("dbo.", "");
                m_SqlTableColumns = new Dictionary<string, SqlTableColumnSchema>();
    
                m_TableSchema = table;
                GetSqlTableColumns();
            }
    
            /// <summary>
            /// Bulk load current datatable to SQL Server.
            /// </summary>
            public void UploadTableToSql()
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(m_SqlConnectionString))
                {
                    bulkCopy.DestinationTableName = m_SqlTableName;
    
                    try
                    {
                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(m_TableSchema);
                    }
                    catch (Exception exception)
                    {
                        string errorMessage = "Failed to bulk load table to SQL.";
    
                        throw new ApplicationException(errorMessage, exception);
                    }
                }
    
            }
    
            /// <summary>
            /// Method creates destination table if table does not exists, otherwise method will alter destination table to match schema of current data table.
            /// </summary>
            public void SyncTableSchemas()
            {
                bool tableExists = DestinationTableExists();
    
                if (!tableExists)
                {
                    CreateSqlTable();
                }
                else
                {
                    // Compare sql table schema against sql server table schema
                    UpdateTableSchema();
                    GetSqlTableColumns();
                }
            }
    
            private void UpdateTableSchema()
            {
                List<SqlTableColumnSchema> missingColumns = GetMissingColumns();
    
                if (missingColumns.Count > 0)
                {
                    string alterTableQuery = string.Format("ALTER TABLE [{0}] ", m_SqlTableName); //ADD [fredA] VARCHAR(20) NULL, [fredB] INT NULL;";
    
                    bool isFirstColumn = true;
    
                    string addColumnQuery = "";
    
                    foreach (SqlTableColumnSchema missingColumn in missingColumns)
                    {
    
    
                        if (isFirstColumn)
                        {
                            addColumnQuery += string.Format("ADD [{0}] {1} NULL", missingColumn.ColumnName, missingColumn.DataType);
                        }
                        else
                        {
                            addColumnQuery += string.Format(", [{0}] {1} NULL", missingColumn.ColumnName, missingColumn.DataType);
                        }
    
                        isFirstColumn = false;
                    }
    
                    alterTableQuery += addColumnQuery + ";";
    
                    using (SqlConnection connection = new SqlConnection(m_SqlConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = alterTableQuery;
    
                            try
                            {
                                connection.Open();
    
                                command.ExecuteNonQuery();
                            }
                            catch (Exception exception)
                            {
                                string errorMessage = "Failed to update destination table schema. Please ensure that schema file is valid.";
    
                                throw new ApplicationException(errorMessage, exception);
                            }
                        }
                    }
                }
    
            }
    
            public List<SqlTableColumnSchema> GetMissingColumns()
            {
                List<SqlTableColumnSchema> missingColumns = new List<SqlTableColumnSchema>();
    
                foreach (DataColumn column in m_TableSchema.Columns)
                {
                    string columnName = column.ColumnName;
    
                    bool columnExistsInTable = m_SqlTableColumns.ContainsKey(columnName);
    
                    if (!columnExistsInTable)
                    {
                        SqlTableColumnSchema newColumnSchema = new SqlTableColumnSchema();
                        newColumnSchema.ColumnName = columnName;
                        newColumnSchema.DataType = SQLGetType(column);
                        newColumnSchema.MaximumLength = 0;
                    }
                }
    
                return missingColumns;
            }
    
            /// <summary>
            /// Method is used to determine if the destination table already exists.
            /// </summary>
            /// <returns></returns>
            private bool DestinationTableExists()
            {
                int objectCount = 0;
                string tableName = m_SqlTableName;
                bool tableExist = false;
    
                string sql = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[" + tableName + "]')";
    
                using (SqlConnection connection = new SqlConnection(m_SqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
    
                    try
                    {
                        connection.Open();
    
    
                        objectCount = (Int32)cmd.ExecuteScalar();
                    }
                    catch (Exception exception)
                    {
                        string errorMessage = "Failed to verify if destination table exists. Please verify that sql user account has the necessary permissions to perform this action.";
    
                        throw new ApplicationException(errorMessage, exception);
                    }
                }
    
                if (objectCount > 0)
                    tableExist = true;
                else
                    tableExist = false;
    
                return tableExist;
    
            }
    
            /// <summary>
            /// Method retrives the columns of the destination sql table
            /// </summary>
            /// <returns></returns>
            private void GetSqlTableColumns()
            {
                string tableName = m_SqlTableName;
                string sql = string.Format("select COLUMN_NAME as ColumnName ,DATA_TYPE as DataType, CHARACTER_MAXIMUM_LENGTH as MaximumLength FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{0}'", tableName);
    
                using (SqlConnection connection = new SqlConnection(m_SqlConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
    
                        try
                        {
                            connection.Open();
    
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int columnNameOrdinal = reader.GetOrdinal("ColumnName");
                                    int dataTypeOrdinal = reader.GetOrdinal("DataType");
                                    int maximumLengthOrdinal = reader.GetOrdinal("MaximumLength");
    
                                    string columnName = reader.GetString(columnNameOrdinal);
                                    string columnDataType = reader.GetString(dataTypeOrdinal);
    
                                    int columnLength = 0;
                                    bool maxLengthColumnIsNull = reader.IsDBNull(maximumLengthOrdinal);
    
                                    if (!maxLengthColumnIsNull) columnLength = reader.GetInt32(maximumLengthOrdinal);
    
                                    bool columnAlreadyAdded = m_SqlTableColumns.ContainsKey(columnName);
    
                                    if (!columnAlreadyAdded)
                                    {
                                        SqlTableColumnSchema columnSchema = new SqlTableColumnSchema();
                                        columnSchema.ColumnName = columnName;
                                        columnSchema.DataType = columnDataType;
                                        columnSchema.MaximumLength = columnLength;
    
                                        m_SqlTableColumns.Add(columnName, columnSchema);
                                    }
    
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            string errorMessage = "Failed to retrieve if destination table’s columns. Please verify that sql user account has the necessary permissions to perform this action.";
    
                            throw new ApplicationException(errorMessage, exception);
                        }
                    }
                }
    
            }
    
            /// <summary>
            /// Method will attempt to create a new sql table based of the DataTable schema object.
            /// </summary>
            private void CreateSqlTable()
            {
                string tableName = m_SqlTableName;
                DataTable table = m_TableSchema;
    
                string sql = GenerateSqlScriptCreateTable(tableName, table);
    
    
                using (SqlConnection connection = new SqlConnection(m_SqlConnectionString))
                {
                    connection.Open();
    
                    try
                    {
                        // Create the sql table
                        using (SqlCommand createTableCommand = new SqlCommand(sql, connection))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exception)
                    {
                        string exceptionMessage = string.Format("CreateFromDataTable(): Failed to create sql table '{0}'", tableName);
                        throw new ApplicationException(exceptionMessage, exception);
                    }
    
                    // Add column indexes and description
                    foreach (DataColumn field in table.Columns)
                    {
                        string scriptAddColumnDescription = GenerateSqlScriptAddDescriptions(tableName, field);
    
                        if (scriptAddColumnDescription != "")
                        {
                            using (SqlCommand addColumnDescriptionCommand = new SqlCommand(scriptAddColumnDescription, connection))
                            {
                                addColumnDescriptionCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
    
    
    
            /// <summary>
            /// Helper method to 'CreateFromDataTable'. Method will generate scripts to create the main body of destination table.
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="table"></param>
            /// <returns></returns>
            private string GenerateSqlScriptCreateTable(string tableName, DataTable table)
            {
                string sql = "CREATE TABLE [" + tableName + "] (\n";
                // columns
                foreach (DataColumn column in table.Columns)
                {
                    sql += "[" + column.ColumnName + "] " + SQLGetType(column) + ",\n";
                }
                sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
                // primary keys
                if (table.PrimaryKey.Length > 0)
                {
                    sql += "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED (";
                    foreach (DataColumn column in table.PrimaryKey)
                    {
                        sql += "[" + column.ColumnName + "],";
                    }
                    sql = sql.TrimEnd(new char[] { ',' }) + "))\n";
                }
    
                //if not ends with ")"
                if ((table.PrimaryKey.Length == 0) && (!sql.EndsWith(")")))
                {
                    sql += ")";
                }
    
                return sql;
            }
    
            /// <summary>
            /// Methods returns a valid sql string representation of an input data type.
            /// </summary>
            /// <param name="type"></param>
            /// <param name="columnSize"></param>
            /// <param name="numericPrecision"></param>
            /// <param name="numericScale"></param>
            /// <returns></returns>
            private string SQLGetType(object type, int columnSize, int numericPrecision, int numericScale)
            {
                switch (type.ToString())
                {
                    case "System.String":
                        return "NVARCHAR(" + ((columnSize == -1) ? "255" : (columnSize > 8000) ? "MAX" : columnSize.ToString()) + ")";
    
                    case "System.Decimal":
                        if (numericScale > 0)
                            return "FLOAT";
                        else if (numericPrecision > 10)
                            return "BIGINT";
                        else
                            return "INT";
    
                    case "System.Double":
                    case "System.Single":
                        return "FLOAT";
    
                    case "System.Int64":
                        return "BIGINT";
    
                    case "System.Int16":
                    case "System.Int32":
                        return "INT";
    
                    case "System.DateTime":
                        return "DATETIME";
    
                    case "System.Boolean":
                        return "BIT";
    
                    case "System.Byte":
                        return "TINYINT";
    
                    case "System.Guid":
                        return "UNIQUEIDENTIFIER";
    
                    default:
                        throw new Exception(type.ToString() + " not implemented.");
                }
            }
    
            /// <summary>
            /// Overload based on DataColumn from DataTable type
            /// </summary>
            /// <param name="column"></param>
            /// <returns></returns>
            private string SQLGetType(DataColumn column)
            {
                return SQLGetType(column.DataType, column.MaxLength, 10, 2);
            }
    
    
            /// <summary>
            /// Helper method to 'CreateFromDataTable'. Method will generate scripts to create descriptions for the destination table's columns.
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            private string GenerateSqlScriptAddDescriptions(string tableName, DataColumn column)
            {
                string sqlScript = "";
    
                string description = GetFieldDescriptionFromExtendedProperties(column);
    
                if (description != "")
                {
                    string fieldName = column.ColumnName;
                    string fieldNameClean = fieldName.Replace(' ', '_');
                    fieldNameClean = CleanString(fieldNameClean);
    
                    string template = @"EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{2}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{0}', @level2type=N'COLUMN',@level2name=N'{1}'";
    
                    sqlScript = string.Format(template, tableName, fieldName, description);
                }
    
                return sqlScript;
            }
    
    
            /// <summary>
            /// Helper method used to get the description of the 'Ampla' the data column.
            /// </summary>
            /// <param name="column">The column in the schema data table to get the field description for</param>
            /// <returns></returns>
            private string GetFieldDescriptionFromExtendedProperties(DataColumn column)
            {
                string description = "";
    
                bool columnHasFieldDescription = column.ExtendedProperties.Contains("Description");
                if (columnHasFieldDescription)
                {
                    description = column.ExtendedProperties["Description"].ToString();
                }
    
                return description;
            }
    
            /// <summary>
            /// Helper method used to clean strings from any invalid values.
            /// </summary>
            /// <param name="inputString"></param>
            /// <returns></returns>
            private string CleanString(string inputString)
            {
                // Replace invalid characters with empty strings. 
                try
                {
                    return Regex.Replace(inputString, @"[^\w]", "", RegexOptions.None);
                }
                // If we timeout when replacing invalid characters,  
                // we should return Empty. 
                catch
                {
                    return String.Empty;
                }
            }
    
            /// <summary>
            /// Determine if column name is valid. The column has to exist in both the SQL Table and Schema file.
            /// </summary>
            /// <param name="columnName"></param>
            /// <returns></returns>
            public bool ColumnIsValid(string columnName)
            {
                bool columnExistInSchema = m_TableSchema.Columns.Contains(columnName);
                bool columnExistInDestinationTable = m_SqlTableColumns.ContainsKey(columnName);
    
                return (columnExistInSchema && columnExistInDestinationTable);
            }
    
            /// <summary>
            /// Get the data type of the column in question
            /// </summary>
            /// <param name="columnName"></param>
            /// <returns></returns>
            public Type GetColumnType(string columnName)
            {
                return m_TableSchema.Columns[columnName].DataType;
            }
        }
    }
