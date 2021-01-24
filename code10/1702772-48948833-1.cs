    var x = new SqlCommand("select gunk from someStuff", myDataConnection);
    try
    {
           x.Connection.Open();
           x.ExecuteQuery();
    }
    finally
    {
          x.Connection.Close();
          x.Dispose(); 
    }
