    public void Insert(string strSQL, List<MySqlParameter> params)
    {
        if(this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, connection)
            foreach(MySqlParameter param in params)
                cmd.Parameters.Add(param);
            
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
