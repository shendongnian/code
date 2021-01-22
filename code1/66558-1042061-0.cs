    using System.Data;
    using System.Data.OleDb;
    using System.Configuration;
       
    public class DataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["KeyName"].ConnectionString;
    
        public DataSet GetData( string sql, string tableName )
        {
            using( var conn = new OleDbConnection( connectionString ) )
            {
                conn.Open();
                var da = new OleDbDataAdapter( sql, conn );
                var ds = new DataSet();
                da.Fill( ds, tableName );
                return ds;
            }
        }
    }
