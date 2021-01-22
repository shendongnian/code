        void DoSomethingWithDatabase_PartDeux()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection("Connect to mah database!"))
            {
                var command = new System.Data.SqlClient.SqlCommand("Get mah data!", connection);
                connection.Open();
                using(var reader = command.ExecuteReader())
                {
                    // read data from data reader (duh)
                }
            }
        }
