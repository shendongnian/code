    public static User GetUser(User pUser)
        {
            using (IDbConnection connection = new SqlConnection(Connection))
            {
                return connection.Query<User>("Select * FROM dbo.Users where userID = @UserId", pUser).FirstOrDefault();
            }
        }
