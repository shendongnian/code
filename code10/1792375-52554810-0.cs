     public void createDB(string _date)
    {
        myConnectionString = string.Empty;
        string dbName = _date;
        myConnectionString = "Data Source=localhost; initial catalog=xxxxxxxx;Persist Security Info=True; user id=xxxxxx; password=xxxxxxx; Connection Timeout=7000;";
        using (SqlConnection conn = new SqlConnection(myConnectionString.ToString()))
        {
            DataSet ds = new DataSet();
            conn.Open();           
            string sql = string.Empty;
            try
            {
                SqlCommand Cmd = new SqlCommand("createdb", conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@dbname", dbName);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string data = e.Message;
                RecordErrorLog("CreateMyFile¶" + data + "¶" + myConnectionString);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
