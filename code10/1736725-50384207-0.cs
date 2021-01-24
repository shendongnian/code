    using (SqlConnection con = new SqlConnection(dc.Con))
    {
    using (SqlCommand cmd = new SqlCommand("SP_ADD", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OrderID", DbType.Int32, orderID);
        con.Open();
        cmd.ExecuteNonQuery();
    }            
    }
