     public string SimpleQuerry(string request, string response)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=SQLOLEDB.1;User ID=" +
                    Constants.DATABASE_USERNAME + ";Password=" +
                    Constants.DATABASE_PASSWORD + ";Initial Catalog=" +
                    Constants.DATABASE_CATALOG + ";Data Source=" +
                    Constants.SERVER_ADRESS;
                SqlCommand command = new SqlCommand(request, conn);
                {
                    conn.Open();
                    string response = Convert.ToString(command.ExecuteScalar());
                    conn.Close();
                    return response; 
                }
            }
