    using System;
    using System.Data;
    using System.Data.SqlServerCe;
    
    namespace DataBase
    {
        public class DBConnection
        {
            private SqlCeConnection sqlConnection;
    
            public DBConnection(string connectionString)
            {
                sqlConnection = new SqlCeConnection(connectionString);
            }
    
            private bool CloseConnection(SqlConnection sqlConnection)
            {
                try
                {
                    sqlConnection.Close();
                    return true;
                }
                catch (SqlException e)
                {
                    //Handle exception
                    return false;
                }
            }
    
            private bool OpenConnection(SqlConnection sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlCeException e)
                {
                    //Handle exception
                    return false;
                }
            }
            public DataTable NonQuery(string sqlString, params SqlCeParameter[] sqlParameters)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("Affected Rows", typeof(int)));
                if (this.OpenConnection(this.sqlConnection))
                {
                    try
                    {
                        SqlCeCommand sqlCommand = new SqlCeCommand(sqlString, this.sqlConnection);
                        sqlCommand.Parameters.AddRange(sqlParameters);
    
                        table.Rows.Add(sqlCommand.ExecuteNonQuery());
                    }
                    catch (SqlCeException e)
                    {
                        table.Rows.Add(0);
                        //Handle exception
                    }
                    finally
                    {
                        this.CloseConnection(this.sqlConnection);
                    }
                }
                return table;
            }
    
            public DataTable Query(string sqlString, params SqlCeParameter[] sqlParameters)
            {
                DataTable table = new DataTable();
                if (this.OpenConnection(this.sqlConnection))
                {
                    try
                    {
                        SqlCeCommand sqlCommand = new SqlCeCommand(sqlString, this.sqlConnection);
                        sqlCommand.Parameters.AddRange(sqlParameters);
    
                        SqlCeDataAdapter sqlDataAdapter = new SqlCeDataAdapter(sqlCommand);
                        sqlDataAdapter.Fill(table);
                    }
                    catch (SqlCeException e)
                    {
                        //Handle exception
                    }
                    finally
                    {
                        this.CloseConnection(this.sqlConnection);
                    }
                }
                return table;
            }
        }
    }
