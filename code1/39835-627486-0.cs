        /// <summary>
        /// Returns AD information for a specified userID.
        /// </summary>
        /// <param name="ntID"></param>
        /// <returns></returns>
        public ADUser GetUser(string ntID)
        {          
            DirectorySearcher search = new DirectorySearcher();        
            search.Filter = String.Format("(cn={0})", ntID);
            search.PropertiesToLoad.Add("mail");
            search.PropertiesToLoad.Add("givenName");
            search.PropertiesToLoad.Add("sn");
            search.PropertiesToLoad.Add("displayName");
            search.PropertiesToLoad.Add("userPrincipalName");
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            return new ADUser(result);
        }
