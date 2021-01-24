    public IDataReader ExecuteReader(string query)
            {
                IDataReader dataReader = null;
                if (this.isMySQL)
                {
                    MySqlCommand cmd = new MySqlCommand(query.Replace("[v-steel].", ""), connection);
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, MSconnection); 
                    dataReader = cmd.ExecuteReader();
                }
                return dataReader;
            }
        
