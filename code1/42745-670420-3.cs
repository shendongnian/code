    myConStr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
    using (var cn = new SqlConnection(myConStr) )
    using (var cmd = new SqlCommand("team5UserCurrentBooks3", cn) ) 
    {
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = userID;
        cmd.Parameters.Add("@book_id", SqlDbType.Int);
        cn.Open();
        for(int i = 0; i<10; i++)
        {
            cmd.Parameters["@book_id"].Value = i;
            cmd.ExecuteNonQuery();
        }
    }
