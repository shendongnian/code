    Sqlconnection connection = new Sqlconnection("/..") // Provide a Correct Connection 
    var test = Decrypt(cli);
    DataTable dt = new DataTable();
    connection.Open();
        
    // Don't goes for this approach. always try to use Store Procedure instead to this.
    SqlCommand command = new SqlCommand("Select * From ResearcherInformation where Email='" + test + "'", connection);
    SqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
       var idid = myReader["Id_Researcher"].ToString();
       // connection.Close(); this is not the propper place for closing a connection.
       ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('access');", true);
    }
    reader.Close();
    connection.Close();
