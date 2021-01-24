    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace Helpers.Sql
    {
    
        public class TableCreator
        {
            #region Instance Variables
            private SqlConnection _connection;
            public SqlConnection Connection
            {
                get { return _connection; }
                set { _connection = value; }
            }
    
            private SqlTransaction _transaction;
            public SqlTransaction Transaction
            {
                get { return _transaction; }
                set { _transaction = value; }
            }
    
            private string _tableName;
            public string DestinationTableName
            {
                get { return _tableName; }
                set { _tableName = value; }
            }
            #endregion
    
            #region Constructor
            public TableCreator() { }
            public TableCreator(SqlConnection connection) : this(connection, null) { }
            public TableCreator(SqlConnection connection, SqlTransaction transaction)
            {
                _connection = connection;
                _transaction = transaction;
            }
    
            public TableCreator(string connectionString)
            {
    
                this.Connection = new SqlConnection(connectionString);
    
            }
    
    
            #endregion
    
            #region Instance Methods
            public object Create(DataTable schema)
            {
                return Create(schema, null);
            }
            public object Create(DataTable schema, int numKeys)
            {
                int[] primaryKeys = new int[numKeys];
                for (int i = 0; i < numKeys; i++)
                {
                    primaryKeys[i] = i;
                }
                return Create(schema, primaryKeys);
            }
            public object Create(DataTable schema, int[] primaryKeys)
            {
                string sql = GetCreateSQL(_tableName, schema, primaryKeys);
    
                SqlCommand cmd;
                if (_transaction != null && _transaction.Connection != null)
                    cmd = new SqlCommand(sql, _connection, _transaction);
                else
                    cmd = new SqlCommand(sql, _connection);
    
                return cmd.ExecuteNonQuery();
            }
    
            public object CreateFromDataTable(DataTable table)
            {
                DestinationTableName = table.TableName;
    
                string sql = GetCreateFromDataTableSQL(_tableName, table);
    
                SqlCommand cmd;
                if (_transaction != null && _transaction.Connection != null)
                    cmd = new SqlCommand(sql, _connection, _transaction);
                else
                    cmd = new SqlCommand(sql, _connection);
    
                return cmd.ExecuteNonQuery();
            }
    
    
            /// <summary>
            /// Creates a Data Relation
            /// </summary>
            /// <param name="_relation"></param>
            /// <returns></returns>
            public object CreateRelationFromDataSet(DataRelation _relation)
            {
    
                string sql = GetCreateFromDatSetRelations(_relation);
    
                SqlCommand cmd;
                if (_transaction != null && _transaction.Connection != null)
                    cmd = new SqlCommand(sql, _connection, _transaction);
                else
                    cmd = new SqlCommand(sql, _connection);
    
                return cmd.ExecuteNonQuery();
    
            }
    
    
            #endregion
    
            #region Static Methods
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="schema"></param>
            /// <param name="primaryKeys"></param>
            /// <returns></returns>
            public static string GetCreateSQL(string tableName, DataTable schema, int[] primaryKeys)
            {
                string sql = "CREATE TABLE [" + tableName + "] (\n";
    
                // columns
                foreach (DataRow column in schema.Rows)
                {
                    if (!(schema.Columns.Contains("IsHidden") && (bool)column["IsHidden"]))
                    {
                        sql += "\t[" + column["ColumnName"].ToString() + "] " + SQLGetType(column);
    
                        if (schema.Columns.Contains("AllowDBNull") && (bool)column["AllowDBNull"] == false)
                            sql += " NOT NULL";
    
                        sql += ",\n";
                    }
                }
                sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
    
                // primary keys
                string pk = ", CONSTRAINT PK_" + tableName + " PRIMARY KEY CLUSTERED (";
                bool hasKeys = (primaryKeys != null && primaryKeys.Length > 0);
                if (hasKeys)
                {
                    // user defined keys
                    foreach (int key in primaryKeys)
                    {
                        pk += schema.Rows[key]["ColumnName"].ToString() + ", ";
                    }
                }
                else
                {
                    // check schema for keys
                    string keys = string.Join(", ", GetPrimaryKeys(schema));
                    pk += keys;
                    hasKeys = keys.Length > 0;
                }
                pk = pk.TrimEnd(new char[] { ',', ' ', '\n' }) + ")\n";
                if (hasKeys) sql += pk;
    
                sql += ")";
    
                return sql;
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="table"></param>
            /// <returns></returns>
            public static string GetCreateFromDataTableSQL(string tableName, DataTable table)
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
            /// 
            /// </summary>
            /// <param name="relation"></param>
            /// <returns></returns>
            public static string GetCreateFromDatSetRelations(DataRelation relation)
            {
    
                // string sql = "";
    
                string childTableName = relation.ChildTable.TableName;
                string parentTableName = relation.ParentTable.TableName;
    
                string sql = "ALTER TABLE [" + childTableName + "] ADD CONSTRAINT \n";
    
                //sql += "ADD CONSTRAINT \n";
    
                // Add the relation - if the name is in the dataset use it.
                if (string.IsNullOrEmpty(relation.RelationName))
                {
                    sql += "FK_" + childTableName + "_" + parentTableName;
                }
                else
                {
                    sql += relation.RelationName;
                }
    
                sql += " FOREIGN KEY \n(\n";
    
                // Set up the keys for the Columns that have foreign 
    
                for (int i = 0; i < relation.ChildKeyConstraint.Columns.Length; i++)
                {
    
                    sql += relation.ChildKeyConstraint.Columns[i].ColumnName;
    
                    if ((relation.ChildKeyConstraint.Columns.Length > 1 ) & i < (relation.ChildKeyConstraint.Columns.Length - 1))
                    {
                        sql += ",";
                    }
    
                    sql += "\n";
    
                }
    
    
                // Set up the reference columns.
    
                sql += "\n) REFERENCES " + parentTableName + "\n(\n";
    
                //   int cols = relation.ParentKeyConstraint.Columns.Length;
    
                for (int i = 0; i < relation.ParentKeyConstraint.Columns.Length; i++)
                {
    
                    sql += relation.ParentKeyConstraint.Columns[i].ColumnName;
    
                    if ((relation.ParentKeyConstraint.Columns.Length > 1) & i < (relation.ParentKeyConstraint.Columns.Length - 1))
                    {
                        sql += ",";
                    }
    
                    sql += "\n";
    
                }
    
                sql += ") \n ON UPDATE NO ACTION  \n ON DELETE NO ACTION";
    
    
                return sql;
            }
    
    
    
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="schema"></param>
            /// <returns></returns>
            public static string[] GetPrimaryKeys(DataTable schema)
            {
                List<string> keys = new List<string>();
    
                foreach (DataRow column in schema.Rows)
                {
                    if (schema.Columns.Contains("IsKey") && (bool)column["IsKey"])
                        keys.Add(column["ColumnName"].ToString());
                }
    
                return keys.ToArray();
            }
    
            // Return T-SQL data type definition, based on schema definition for a column
            public static string SQLGetType(object type, int columnSize, int numericPrecision, int numericScale)
            {
                switch (type.ToString())
                {
                    case "System.String":
                        return "VARCHAR(" + ((columnSize == -1) ? "255" : (columnSize > 8000) ? "MAX" : columnSize.ToString()) + ")";
    
                    case "System.Decimal":
                        if (numericScale > 0)
                            return "REAL";
                        else if (numericPrecision > 10)
                            return "BIGINT";
                        else
                            return "INT";
    
                    case "System.Double":
                    case "System.Single":
                        return "REAL";
    
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
    
            // Overload based on row from schema table
            public static string SQLGetType(DataRow schemaRow)
            {
                return SQLGetType(schemaRow["DataType"],
                                    int.Parse(schemaRow["ColumnSize"].ToString()),
                                    int.Parse(schemaRow["NumericPrecision"].ToString()),
                                    int.Parse(schemaRow["NumericScale"].ToString()));
            }
            // Overload based on DataColumn from DataTable type
            public static string SQLGetType(DataColumn column)
            {
                return SQLGetType(column.DataType, column.MaxLength, 10, 2);
            }
            #endregion
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="connectionString"></param>
            /// <param name="tableName"></param>
            /// <param name="table"></param>
            public static void BulkInsertDataTable(string connectionString, string tableName, DataTable table)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );
    
                    bulkCopy.DestinationTableName = tableName;
                    connection.Open();
    
                    bulkCopy.WriteToServer(table);
                    connection.Close();
                }
            }
        }
    
    
        /// <summary>
        /// 
        /// </summary>
        public class CreateServerModel
        {
    
            public void CreateServerTables(DataSet ds, SqlConnection conn)
            {
    
                TableCreator STC = new TableCreator(conn);
    
                STC.Connection.Open();
                foreach (DataTable dt in ds.Tables)
                {
    
                    STC.CreateFromDataTable(dt);
    
                }
                STC.Connection.Close();
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ds"></param>
            /// <param name="conn"></param>
            public void CreateTableRelations(DataSet ds, SqlConnection conn)
            {
    
                TableCreator STC = new TableCreator(conn);
    
                STC.Connection.Open();
    
                foreach (DataRelation relation in ds.Relations)
                {
                    //STC.Get
                    //string chTblName = item.ChildTable.TableName;
                    //string prntTblName = item.ParentTable.TableName;
    
    
                    //List<DataColumn> lchColumns = relation.ChildKeyConstraint.Columns.ToList();
                    //List<DataColumn> parColumns = relation.ParentKeyConstraint.Columns.ToList();
                    //string prntTblName = relation.ParentTable.TableName;
                    try
                    {
                        STC.CreateRelationFromDataSet(relation);
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message.ToString();
                        // throw;
                        msg += "";
                    }
    
    
                }
    
                STC.Connection.Close();
            }
    
        }
    }
