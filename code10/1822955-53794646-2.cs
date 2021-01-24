    using (SqlConnection con = new SqlConnection(connectionString)) {       
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@param2", System.Data.SqlDbType.VarChar, 50) { Value = someValueHere });
            cmd.Parameters.Add(new SqlParameter("@param3", System.Data.SqlDbType.VarChar, 50) { Value = someValueHere2 });
            cmd.CommandType = commandType.Text;
            cmd.ExecuteNonQuery();
    }
