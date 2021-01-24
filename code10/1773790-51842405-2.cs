        if(filters != null && filters.hospitalID != 0)
        {
            using (SqlConnection conn = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand(sqlParam, conn))
            {
                cmd.Parameters.Add(new SqlParameter("ParamValue", filters.hospitalID ));
                da.Fill(ds);
            }
        }
        else
        {
             using (SqlConnection conn = new SqlConnection())
             using (SqlCommand cmd = new SqlCommand(sqlWithoutParam, conn))
             {
                da.Fill(ds);
             }
        }
    
