    ArrayList names = new ArrayList();
    
    int rowsinmachgrp = getnumofrows();//gets no of rows in table
    
    SqlConnection dataConnection = new SqlConnection();
    dataConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SumooHAgentDBConnectionString"].ConnectionString;
    SqlCommand dataCommand = new SqlCommand("select MachineGroupName from MachineGroups", dataConnection);
    
    
      dataConnection.Open();
      SqlDataReader rdr = dataCommand.ExecuteReader();
      while (rdr.Read())
      {
        names.Add(rdr.GetString(0));
      }
    dataCommand.Dispose();
    dataConnection.Dispose();
