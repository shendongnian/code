    public void LoadData(ref DataTable dt)
        {           
            using (var connection = new SqlConnection("your connection string here"))
            {
                connection.Open();                
                using (SqlCommand command = new SqlCommand(@"SELECT CONVERT(bit, ISNULL(yourSqlColumn which decides, 0)) as Active from yourTable ", connection))
                {                                                               
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();                        
                    }
                }
                connection.Close();
            }            
        }
