            SqlConnection con = new SqlConnection("connection string");
            bool resp = false;
            try
            {
                con.OpenAsync();
                resp = true;
            }
            catch (SqlException ex)
            {
                //use the ex message
                resp = false;
            }
            catch (Exception ex)
            {
                resp = false;
            }
            finally
            {
                con.Close();
            }
