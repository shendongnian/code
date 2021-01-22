    public class MySqlDataSource : SqlDataSource
    {
      public string _customConnectionStr; //Allow a custom connection still
      public override string ConnectionString {
        //Default the connection if a custom isn't set
        get { return _customConnectionStr  ?? DBConnections.DefaultConnection; }
        set { _customConnectionStr = value; } 
      }
    }
