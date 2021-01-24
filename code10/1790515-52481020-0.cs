     SqlConnectionStringBuilder builder =  new SqlConnectionStringBuilder();
    
            // Supply the additional values.
            builder.DataSource = Server.Text +":" Port.Text;
            builder.UserID = userName;
            builder.Password = userPassword;
            builder.InitialCatelog = Database.Text;
     using (SqlConnection connection = 
                    new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    // Now use the open connection.
                    Console.WriteLine("Database = " + connection.Database);
                }
