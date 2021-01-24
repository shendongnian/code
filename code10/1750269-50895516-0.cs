                   Mysql database connection is like this
                      string ConnectionString = "SERVER=localhost;" 
                        + "DATABASE=testdb;" 
                        + "User Id=wsuser;" 
                        + "PASSWORD=12345;" 
                         MySqlConnection Connection = new 
                         MySqlConnection(ConnectionString);
                         Connection.Open();
                     Use MySqlconnection to connect Mysql database and Sqlconnection to connect Sqlserver.
