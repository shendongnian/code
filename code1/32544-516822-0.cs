    var connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
    
            var conn = new SqlConnection(connectionString);
    
            var comm = new SqlCommand("YourStoredProc", conn) { CommandType = CommandType.StoredProcedure };
    
            try
            {
                conn.Open();
    
    
                // Create variables to match up with session variables
                var CloseSchoolID = Session["sessCloseSchoolID"];
    
    
                //  SqlParameter for each parameter in the stored procedure YourStoredProc
                var prmClosedDate = new SqlParameter("@prmClosedDate", closedDate);
                var prmSchoolID = new SqlParameter("@prmSchoolID", CloseSchoolID);
    
                // Pass the param values to YourStoredProc
                comm.Parameters.Add(prmClosedDate);
                comm.Parameters.Add(prmSchoolID);
    
                comm.ExecuteNonQuery();
            }
    
            catch (SqlException sqlex)
            {
            }
    
            finally
            {
                conn.Close();
            }
