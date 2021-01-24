    string procedureName = "spInsertFormIssue";
    private void AddQueue(string procedureName)
        {
            SqlConnection conn = forconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(procedureName,conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Qdatetime", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.ExecuteNonQuery();
            conn.Close();          
        }
