    System.Data.SqlClient.SqlConnection dataConnection = new SqlConnection();
                dataConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["NameOfConnectionString"].ConnectionString;
    
                System.Data.SqlClient.SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
