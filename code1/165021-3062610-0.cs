    public class SomeObj
    {
        SqlConnection _conn = new SqlConnection(connString);
    
        public SomeObj() { _conn.Open(); }
    
        public SqlConnection Connection
        {
            get
            {
                return _conn;
            }
        }
    }
