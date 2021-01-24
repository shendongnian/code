    public class DbHelper
    {
        #region Private methods
    
        private static OracleConnection GetConnection()
        {
            string connectionString = DbConnectionString.ConnectionString;
            return new OracleConnection(connectionString);
        }
    
        private static OracleCommand GetCommand(OracleConnection connection, string commandText, OracleParameter[] param, bool isProcedure)
        {
            OracleCommand dbCommand = new OracleCommand();
            dbCommand.Connection = connection;
            dbCommand.CommandText = commandText;
            if (param != null)
                dbCommand.Parameters.AddRange(param);
            if (isProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;
            return dbCommand;
        }
        #endregion
    
        #region public methods
        public static DataTable GetDataTable(string commandText, OracleParameter[] odbcPrams, bool isProcedure = false)
        {
            DataTable dt = new DataTable();
            using (OracleConnection ODBCConn = GetConnection())
            {
                using (OracleCommand dbCommand = GetCommand(ODBCConn, commandText, odbcPrams, isProcedure))
                {
                    ODBCConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(dbCommand);
                    da.Fill(dt);
                }
            }
    
            return dt;
        }
        #endregion
    }
