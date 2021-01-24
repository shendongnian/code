    public enum rdbmsTypes
    {
        SQLServer,
        Oracle
    }
    public class ADONetFactory
    {
        private rdbmsTypes _dbType;
        private string _connectionString;
        public ADONetFactory (rdbmsTypes dbType, string connectionString)
	    {
            _dbType = dbType;
            _connectionString = connectionString;
	    }
        public System.Data.IDbConnection GetConnecion()
        {
            switch(_dbType)
            {
                case rdbmsTypes.SQLServer:
                    return new System.Data.SqlClient.SqlConnection(_connectionString);
                case rdbmsTypes.Oracle:
                    return new Oracle.DataAccess.Client.OracleConnection(_connectionString);
            }
            ThrowNotSupportedException();
        }
        public System.Data.IDbCommand GetCommand()
        {
            switch (_dbType)
            {
                case rdbmsTypes.SQLServer:
                    return new System.Data.SqlClient.SqlCommand();
                case rdbmsTypes.Oracle:
                    return new Oracle.DataAccess.Client.OracleCommand();
            }
            ThrowNotSupportedException();
        }
        private void ThrowNotSupportedException()
        {
            throw new NotSupportedException("The RDBMS type " + Enum.GetName(typeof(rdbmsTypes), _dbType) + " is not supported"); 
        }
    }
