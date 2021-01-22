    Private Boolean UpdateTable()
    {
        int rowsUpdated = 0;
        string sql = "IF EXISTS(Select A.CNum FROM TABLEA A, TABLEB B WHERE A.CID= B.CID AND   A.CNum is NULL AND CID=@cID) BEGIN ..... END" 
    
        using(SqlConnection con = new SqlConnection("your-connection-string-here"))
        {
            using(SqlCommand cmd = new SqlCommand(sql, con)) 
            {
               con.Open();
               rowsUpdated = cmd.ExecuteNonQuery();
               con.Close();
            }
        }
        return (rowsUpdated > 0);
    }
