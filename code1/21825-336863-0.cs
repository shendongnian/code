    SqlConnection conn = null;
    conn = new SqlConnection("yourConnectionString");
    conn.Open();
    string strSQLCommand = "CREATE VIEW vw_YourView AS SELECT YOurColumn FROM YourTable";
    SqlCommand command = new SqlCommand(strSQLCommand, conn); 
    string returnvalue = (string)command.ExecuteScalar(); 
    conn.Close();
 
