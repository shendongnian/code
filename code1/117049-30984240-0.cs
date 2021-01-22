    private static string GetUserNameById(string sId, string connStr)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
            System.Data.SqlClient.SqlCommand command;
            try
            {
                // To be Assigned with Return value from DB
                object getusername;
                             
                command = new System.Data.SqlClient.SqlCommand();
                command.CommandText = "Select userName from [User] where userid = @userid";
                command.Parameters.AddWithValue("@userid", sId);
                
                command.CommandType = CommandType.Text;
                conn.Open();
                command.Connection = conn;
                //Execute
                getusername = command.ExecuteScalar();
                //check for null due to non existent value in db and return default empty string
                string UserName = getusername == null ? string.Empty : getusername.ToString();
                
                return UserName;
                             
            }
            catch (Exception ex)
            {
                throw new Exception("Could get username", ex);
            }
            finally
            {
                conn.Close();
            }
            
        }
