        string line1= (" Insert into PMRecordedSale("+.....)
    
    SqlConnection myConnection = new SqlConnection();
                myConnection = (SqlConnection)(Dts.Connections["DbConn"].AcquireConnection(Dts.Transaction) as SqlConnection);
        
           SqlCommand myCommand = new SqlCommand(line1, myConnection);
                            myCommand.ExecuteNonQuery();
