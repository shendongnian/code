    SqlConnection SqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyLocalSQLServer"].ConnectionString.ToString());
        System.Data.SqlClient.SqlCommand sqlcomm = new System.Data.SqlClient.SqlCommand("Validate", SqlConn);
        string returnValue = string.Empty;
        try
        {
            SqlConn.Open();
            sqlcomm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@a", SqlDbType.VarChar, 50);
            param.Direction = ParameterDirection.Input;
            param.Value = Username;
            sqlcomm.Parameters.Add(param);
            SqlParameter retval = new SqlParameter("@b", SqlDbType.VarChar, 50);
            retval.Direction = ParameterDirection.ReturnValue;
            sqlcomm.Parameters.Add(retval);
            
            sqlcomm.ExecuteNonQuery();
            SqlConn.Close();
            string retunvalue = retval.Value.ToString();
         }
