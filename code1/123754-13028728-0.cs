            public static void GetTableSpaceUsed(string tableName)
        {
            SqlConnection Conn = new SqlConnection(SqlHelper.GetConnection());
            SqlCommand spaceused = new SqlCommand("sp_spaceused", Conn);
            spaceused.CommandType = CommandType.StoredProcedure;
            spaceused.Parameters.AddWithValue("@objname", tableName);
            Conn.Open();
            SqlDataReader reader = spaceused.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Name: " + reader["name"]);
                    Console.WriteLine("Rows: " + reader["rows"]);
                    Console.WriteLine("Reserved: " + reader["reserved"]);
                    Console.WriteLine("Data: " + reader["data"]);
                    Console.WriteLine("Index size: " + reader["index_size"]);
                }
            }
        }
