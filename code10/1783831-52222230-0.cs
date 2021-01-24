    public static User GetUser(User pUser)
        {
            using (IDbConnection connection = new SqlConnection(Connection))
            {
                var query = string.Format("SELECT * FROM dbo.USERS where userID == {0}", pUser.UserID);
                return connection.Query<User>(query);
            }
        }
