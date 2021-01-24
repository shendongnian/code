        string cmdText = @"UPDATE DBO.TABLE SET BitColumn =  = @bVal";
        bool b = true;
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            SqlCommand sql = new SqlCommand(cmdText, conn);
            SqlParameter boolParameter = new SqlParameter("@bVal", SqlDbType.Bit);
            boolParameter.Direction = ParameterDirection.Input;
            boolParameter.Value = b;
            sql.Parameters.Add(boolParameter);
            conn.Open();
            sql.ExecuteNonQuery();
        }
