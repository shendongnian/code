    public class Employee
    {
      private SqlConnection _connection;
      public int ID {get;set;}
      public string EmpName {get;set;}
      public double Salary {get;set;}
      public string Department  {get;set;}
      
  
    /// <summary>
    /// Sets the connection.
    /// </summary>
    public void SetConnection()
    {
        //assuming connection string is placed in settings file from Project Properties.
        _connection = new SqlConnection(Settings.Default.connectionString);
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
        _connection.Open();
    }
    
    /// <summary>
    /// Closes the connection.
    /// </summary>
    public void CloseConnection()
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
      public DataTable GetEmployees()
      {
           DataTable dt = new DataTable("Employee");
           // using above connection
           SetConnection();
          using(SqlCommand command = new SqlCOmmand("commandText",_connection))
          {
             using(SqlDataReader reader = command.ExecuteReader())
             {
                  dt.Load(reader);
             }
          }
           return dt;
      }
    }
