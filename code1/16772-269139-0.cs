    // Variable for storing the connection passed to the constructor
    private System.Data.SqlClient.SqlConnection _Connection;
    public DataContext(System.Data.SqlClient.SqlConnection Connection) : base(Connection)
    {
        // Only set the reference if the connection is Valid and Open during construction
        if (Connection != null)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                _Connection = Connection;                    
            }
        }           
    }
    protected override void Dispose(bool disposing)
    {        
        // Only try closing the connection if it was opened during construction    
        if (_Connection!= null)
        {
            _Connection.Close();
            _Connection.Dispose();
        }
        base.Dispose(disposing);
    }
