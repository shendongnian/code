    string connectionString = ConfigurationManager.AppSettings["ConnectDB"];
            SqlConnection sn = new SqlConnection(connectionString);
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sn.Open();
            SqlCommand dCmd = new SqlCommand("dbo.HelloWorld", sn);
            dCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = null;
            rdr = dCmd.ExecuteReader();
            while (rdr.Read())
                {
                for (int i = 0; i < rdr.FieldCount; i++)
                    Response.Write(rdr[i]);
                }
            sn.Close();
            }
