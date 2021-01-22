        ///<summary>Update Batch records in DataTable</summary>
        ///<remarks></remarks>
        public void UpdateTables(System.Data.DataTable DataTable)
        {
            if (DataTable.TableName.Length == 0)
            {
                throw new Exception("The DataTable tablename is nedded.");
            }
            if (this.State == ConnectionState.Closed)
            {
                this.Connect();
            }
            try
            {
                string strTablename = DataTable.TableName, strSQL;
                System.Data.IDbDataAdapter dt = null;
                if (DataTable.TableName.Length == 0)
                {
                    throw new Exception("Tablename can't be null.");
                }
                strSQL = "SELECT * FROM " + strTablename;
                if (m_DatabaseType == DatabaseTypeEnum.Access)
                {
                    dt = new System.Data.OleDb.OleDbDataAdapter(strSQL, m_ConnectionString);
                    System.Data.OleDb.OleDbCommandBuilder cb_a
                        = new System.Data.OleDb.OleDbCommandBuilder((System.Data.OleDb.OleDbDataAdapter)dt);
                    dt.InsertCommand = cb_a.GetInsertCommand();
                    dt.UpdateCommand = cb_a.GetUpdateCommand();
                    dt.DeleteCommand = cb_a.GetDeleteCommand();
                    ((System.Data.OleDb.OleDbDataAdapter)dt).Update(DataTable);
                }
                else if (m_DatabaseType == DatabaseTypeEnum.SQLServer)
                {
                    dt = new System.Data.SqlClient.SqlDataAdapter(strSQL, m_ConnectionString);
                    System.Data.SqlClient.SqlCommandBuilder cb_s
                        = new System.Data.SqlClient.SqlCommandBuilder((System.Data.SqlClient.SqlDataAdapter)dt);
                    dt.InsertCommand = cb_s.GetInsertCommand();
                    dt.UpdateCommand = cb_s.GetUpdateCommand();
                    dt.DeleteCommand = cb_s.GetDeleteCommand();
                    ((System.Data.SqlClient.SqlDataAdapter)dt).Update(DataTable);
                }
                else if (m_DatabaseType == DatabaseTypeEnum.Oracle)
                {
                    dt = new System.Data.OracleClient.OracleDataAdapter(strSQL, m_ConnectionString);
                    System.Data.OracleClient.OracleCommandBuilder cb_o
                        = new System.Data.OracleClient.OracleCommandBuilder((System.Data.OracleClient.OracleDataAdapter)dt);
                    dt.InsertCommand = cb_o.GetInsertCommand();
                    dt.UpdateCommand = cb_o.GetUpdateCommand();
                    dt.DeleteCommand = cb_o.GetDeleteCommand();
                    ((System.Data.OracleClient.OracleDataAdapter)dt).Update(DataTable);
                }
                else if (m_DatabaseType == DatabaseTypeEnum.Odbc)
                {
                    dt = new System.Data.Odbc.OdbcDataAdapter(strSQL, m_ConnectionString);
                    System.Data.Odbc.OdbcCommandBuilder cb_c
                        = new System.Data.Odbc.OdbcCommandBuilder((System.Data.Odbc.OdbcDataAdapter)dt);
                    dt.InsertCommand = cb_c.GetInsertCommand();
                    dt.UpdateCommand = cb_c.GetUpdateCommand();
                    dt.DeleteCommand = cb_c.GetDeleteCommand();
                    ((System.Data.Odbc.OdbcDataAdapter)dt).Update(DataTable);
                }
                else
                {
                    throw new NotImplementedException();
                }
                DataTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
