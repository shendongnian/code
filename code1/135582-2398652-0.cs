            string Server = "localhost";
            string Database = "\\btc2\\state\\states.mdb";
            string Username = "";
            string Password = "Lhotse";
            string ConnectionString = "Data Source = " + Server + ";" +
                                      "Initial Catalog = " + Database + ";" + 
                                      "User Id = '';" + 
                                      "Password = " + Password + ";";
            bool bDatabaseOk = false;
            using (SqlConnection SQLConnection = new SqlConnection()){
                try
                {
                    SQLConnection.ConnectionString = ConnectionString;
                    SQLConnection.Open();
                    bDatabaseOk = true;
                }
                catch (SqlException Ex)
                {
                   // Handle the SqlException here....
                   //
                   //can't connect
                    bDatabaseOk = false;
                }
            } 
            return bDatabaseOk;
