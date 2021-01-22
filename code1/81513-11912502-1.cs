    bool res = false;
    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
    {
        using (SqlCommand comm = new SqlCommand("dbo.MyFunction", conn))
        {
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@MyParam", SqlDbType.Int);
            // You can call the return value parameter anything, .e.g. "@Result".
            SqlParameter p2 = new SqlParameter("@Result", SqlDbType.Bit);
            p1.Direction = ParameterDirection.Input;
            p2.Direction = ParameterDirection.ReturnValue;
                        
            p1.Value = myParamVal;
            comm.Parameters.Add(p1);
            comm.Parameters.Add(p2);
            conn.Open();
            comm.ExecuteNonQuery();
            if (p2.Value != DBNull.Value)
                res = (bool)p2.Value;
        }
    }
    return res;
