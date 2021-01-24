        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            try
            {
                ApplicationUser apUser;
                List<ApplicationUser> userList = new List<ApplicationUser>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_UsersReadAll", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand cmd2 = new SqlCommand("sp_GetUserRolls", con);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        apUser = new ApplicationUser();
                        apUser.Id = Convert.ToString(reader["Id"]);
                        apUser.UserName = reader["Username"].ToString();
                        apUser.FirstName = reader["FirstName"].ToString();
                        apUser.LastName = reader["LastName"].ToString();
                        apUser.Email = reader["Email"].ToString();
                        userList.Add(apUser);
                    }
                    // You can refactor this code in another method for don't have to write it both
                    reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        apUser = new ApplicationUser();
                        apUser.Id = Convert.ToString(reader["Id"]);
                        // If id doesn't exists, we can continue and add the item 
                        if(!userList.Exists(o=>o.Id==apUser.Id))
                        {
                            apUser.UserName = reader["Username"].ToString();
                            apUser.FirstName = reader["FirstName"].ToString();
                            apUser.LastName = reader["LastName"].ToString();
                            apUser.Email = reader["Email"].ToString();
                            userList.Add(apUser);
                        }
                    }
                    con.Close();
                }
                return userList;
            }
            catch (Exception)
            {
                // Actually it's like if you had not try / catch
                throw;
            }
        }
