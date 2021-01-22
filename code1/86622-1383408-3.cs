       SqlDataAdapter myAdapter = new SqlDataAdapter(); 
       myAdater.Connection = myConnection;
    
       SqlCommand newCommand = new SqlCommand("spPminfoList");
       newCommand.CommandType = CommandType.StoredProcedure;
       myAdapter.SelectCommand = newCommand;
