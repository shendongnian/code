    public Class Repository
    {
       private SqlConnection _connection {get; set;}
    
       public void SetConnection(SetConnection connection)
       {
            _connection = connection;
       }
       
       public string GetSomething()
       {
           _connection.Open();
           //do stuff with _connection
           _connection.Close();
       }
    }
