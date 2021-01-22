        void DoSomethingWithDatabase()
        {
            var connection = new System.Data.SqlClient.SqlConnection("Connect to mah database!");
            try
            {
                var command = new System.Data.SqlClient.SqlCommand("Get mah data!", connection);
                connection.Open();
                try
                {
                    var reader = command.ExecuteReader();
                    try
                    {
                        try
                        {
                            // read data from data reader (duh)
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                    finally
                    {
                        reader.Dispose();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            finally
            {
                connection.Dispose();
            }
        }
