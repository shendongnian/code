    Line 30:         sUsername.Trim();
    Line 31:         sPassword.Trim();
    Line 32:         string ConnectionString = WebConfigurationManager.ConnectionStrings["dbnameConnectionString"].ConnectionString;
    Line 33:         SqlConnection myConnection = new SqlConnection(ConnectionString);
    Line 34:         try
