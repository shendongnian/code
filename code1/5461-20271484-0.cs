         Using(SqlConnection conn=new SqlConnection(ConnectionString)
                {
                    Conn.Open()
                // Execute sql statements here.
               // You do not have to close the connection explicitly here as "USING" will close the connection once the object Conn becomes out of the defined scope.
                }
