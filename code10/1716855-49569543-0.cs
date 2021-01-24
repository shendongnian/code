        /// <summary>
        /// set authentication of SharePoint online
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void setOnlineCredential(ClientContext clientContext,string userName,string password)
        {
            //set the user name and password
            SecureString secureString = new SecureString();
            foreach (char c in password.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            clientContext.Credentials = new SharePointOnlineCredentials(userName, secureString);           
        }
        /// <summary>
        /// set authentication of SharePoint on-premise(SharePoint 2010/2013/2016)
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        public static void setClientCredential(ClientContext clientContext, string userName, string password, string domain)
        {
            clientContext.Credentials = new NetworkCredential(userName, password, domain);
        }
