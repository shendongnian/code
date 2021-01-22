        public static class UserFactory
        {
            public static User LoadUser(SqlDataReader reader)
            {
                int id = (int)reader["userID"];
                return new User(id);
            }
            public static UserProfile LoadUserProfile(SqlDataReader reader)
            {
                User user = LoadUser(reader);
                // extra properties
                string url = (string)reader["url"];
                return new UserProfile(user, url);
            }
        }
