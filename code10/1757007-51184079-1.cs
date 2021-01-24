    public IDataReader ExecuteReader(string query) 
        {
             IDataReader dataReader = null; 
           if (this.isMySQL) 
          {
             MySqlCommand cmd = new MySqlCommand(query.Replace("[myDataBase].", ""), 
             connection); 
             dataReader = cmd.ExecuteReader(); 
          } 
          else 
          { 
            SqlCommand cmd = new SqlCommand(query, connection); 
            dataReader = cmd.ExecuteReader(); 
          }
            return dataReader; 
      }
