    public string ExecuteReader(string SqlText)
    {
        SqlCommand cmd;
        string retrunValue = "";
        try
        {
            c.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;                
            cmd.Connection = c;
            cmd.CommandText = SqlText;
            retrunValue = Convert.ToString(cmd.ExecuteScalar());
            c.Close();
        }
        catch (Exception SqlExc)
        {
            c.Close();
            throw SqlExc;
        }
        return (retrunValue);
    }
