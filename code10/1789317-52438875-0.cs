    public IEnumerable<ApplicationUser> GetAllUsers()
    {
        try
        {
            List<ApplicationUser> userList = new List<ApplicationUser>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"BEGIN
                                                        exec sp_UsersReadAll
                                                        exec sp_GetUserRolls 
                                                    END", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicationUser apUser = new ApplicationUser();
                    apUser.Id = Convert.ToString(reader["Id"]);
                    apUser.UserName = reader["Username"].ToString();
                    apUser.FirstName = reader["FirstName"].ToString();
                    apUser.LastName = reader["LastName"].ToString();
                    apUser.Email = reader["Email"].ToString();
                    userList.Add(apUser);
                }
                reader.NextResult();
                while (reader.Read())
                {
                    ApplicationUserRoll apUserRoll = new ApplicationUserRoll();
                    apUserRoll.Id = Convert.ToString(reader["Id"]);
                    apUserRoll.UserId = reader["UserId"].ToString();
                    userList.Single(u => u.Id == apUserRoll.UserId).Rolls.Add(apUserRoll);
                }
                con.Close();
            }
            return userList;
        }
        catch (Exception)
        {
            throw;
        }
    }
