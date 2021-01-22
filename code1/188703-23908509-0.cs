        {
            DataTable objDt = new DataTable();
            OdbcConnection odbccon = new OdbcConnection();
            try
            {
                odbccon.ConnectionString =
                 "Dsn=Dsn;" +
                 "Uid=databaseuserid;" +
                 "Pwd=databasepassword;";
                odbccon.Open();
                OdbcCommand cmd = new OdbcCommand("{call usp_GetEmpDetailsByIDanddepid(?,?)", odbccon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", siteid);
                cmd.Parameters.AddWithValue("@DocumentIDs", docid);
                cmd.ExecuteNonQuery();
            }
            catch (OdbcException objEx)
            {
                string str = objEx.Message;
            }
            finally { odbccon.Close(); }
        }
