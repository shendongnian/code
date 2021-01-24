    public Company getCompany(int _softID)
    {
        Company temp = new Company();
        conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        SqlCommand command = new SqlCommand(@"SELECT c.CompanyId, Company_Name, UserId, UserName "+
                                             "FROM company As c"+
                                             "JOIN [User] As u ON c.CompanyId = u.CompanyId"+
                                             "WHERE softID = @softID;", conn);
        command.Parameters.Add("@softID", SqlDbType.Int).Value = _softID;
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp.CompanyID = int.Parse(reader["companyID"].ToString());
                temp.companyName = reader["company_name"].ToString();
                temp.CompanyUsers.Add(new User()
                                      {
                                          UserID = int.Parse(reader["UserId"].ToString()),
                                          UserName = reader["UserName"].ToString()
                                      });
            }
            conn.Close();
        }
        return temp;
    }
