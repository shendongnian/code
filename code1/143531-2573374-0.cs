    SQL = "DELETE FROM Task where TaskId = @taskid"; 
 
    dbConn.Open(); 
 
    dbCommand = new SqlCeCommand(SQL, dbConn); 
    dbCommand.Parameters.Add("@taskid", SqlDbType.Int);
    dbCommand.Parameters["@taskid"].Value = index;
    dbCommand.ExecuteNonQuery(); 
 
    dbConn.Close(); 
