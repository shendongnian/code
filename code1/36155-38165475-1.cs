            using (SqlConnection conn = new SqlConnection(@"Data Source=(local);Initial Catalog=master;Persist Security Info=True;Integrated Security =SSPI;"))
            {
               
                string strSql = "USP_GetDBDetails";
                SqlCommand sqlcomm = new SqlCommand();
                sqlcomm.CommandText = strSql;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Connection = conn;
                SqlParameter returnValueParam = sqlcomm.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValueParam.Direction = ParameterDirection.ReturnValue;
                conn.Open();
    **// Reader Section**
                SqlDataReader rdr = sqlcomm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr); // Get the Reultset into a DataTable so we can use it !
                rdr.Close();  // Important to close the reader object before reading the return value.
    // Lets get the return value which in this case will be the SPID for this connection.
               string spid_str = returnValueParam.Value.ToString();
               int spid = (int)sqlcomm.Parameters["@ReturnValue"].Value; // Another Way to get the return value.
    
               Console.WriteLine("SPID For this Conn = {0} ", spid);
    // To use the Reult Sets that was returned by the SP:
            foreach (DataRow dr in dt.Rows)
            {
                string dbName = dr["Name"].ToString();
                // Code to use the Other Columns goes here
            }
          }
