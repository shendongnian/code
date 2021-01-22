    myConStr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
    myConn = new SqlConnection(myConStr);
    myConn.Open();
    
    myCommand = new System.Data.SqlClient.SqlCommand("team5UserCurrentBooks3", myConn); 
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.AddWithValue("@book_id", bookID);
    myCommand.Parameters.AddWithValue("@user_id", userID);
    myCommand.ExecuteNonQuery();
    
    myCommand.Parameters.Clear();
    myCommand.CommandText= "NewStoredProcedureName";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.AddWithValue("@foo_id", fooId);
    myCommand.Parameters.AddWithValue("@bar_id", barId);
    mycommand.ExecuteNonQuery();
    
    myCommand.Parameters.Clear();
    myCommand.CommandText = " SELECT * FROM table1 WHERE ID = @TID;"
    myCommand.CommandType = CommandType.Text;
    myCommand.Parameters.AddWithValue("@tid", tId);
    SqlReader rdr;
    rdr = myCommand.ExecuteReader();
