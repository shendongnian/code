    public int theId(string name)
    {
        SqlCommand command2 = new SqlCommand("Select userId from dbo.userDataTbl where userName=@username", this.connection);
        command2.Parameters.AddWithValue("@username", name);
        this.connection.open();
        try
        {
            SqlDataReader reader = command2.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string foundId = String.Format("{0}", reader["userId"]);
                    int id = Convert.ToInt32(foundId);
                    return id; 
                }
            }
            else
            {
                return -1;
            }
        }
        catch(Exception ex)
        {
    
        }                
    }
