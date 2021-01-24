    using (SqlConnection con = new SqlConnection(connectionString)) {       
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new new SqlParameter("@param2", System.Data.SqlDbType.VarChar, 50) { Value = someValueHere });
            cmd.Parameters.Add(new new SqlParameter("@param3", System.Data.SqlDbType.VarChar, 50) { Value = someValueHere2 });
            cmd.CommandType = commandType.Text;
            cmd.ExecuteNonQuery();
    }
