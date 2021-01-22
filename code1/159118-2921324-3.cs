        /// <summary>
        /// Gets User object by user name.
        /// </summary>
        /// <param name="username">UserName of the user</param>
        /// <returns>User Object</returns>
        public static User GetUserByUsername(string username)
        {
            try
            {
                return Adapter.GetUserByUserName(username)[0].ToEntity<AppUser>();
            }
            catch
            {
                return null;
            }
        }
