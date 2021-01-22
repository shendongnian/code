        /// <summary>
        /// Locks a user account
        /// </summary>
        /// <param name="userName">The name of the user whose account you want to unlock</param>
        /// <remarks>
        /// This actually trys to log the user in with a wrong password. 
        /// This in turn will lock the user out
        /// </remarks>
        public void LockAccount(string userName)
        {
            DirectoryEntry user = GetUser(userName);
            string path = user.Path;
            string badPassword = "SomeBadPassword";
            int maxLoginAttempts = 10;
            for (int i = 0; i &lt maxLoginAttempts; i++)
            {
                try
                {
                    new DirectoryEntry(path, userName, badPassword).RefreshCache();
                }
                catch (Exception e)
                {
                }
            }
            user.Close();
        }
