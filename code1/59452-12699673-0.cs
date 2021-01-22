        /// <summary>
        /// Returns the domain of the logged in user.  
        /// Therefore, if computer is joined to a domain but user is logged in on local account.  String.Empty will be returned.
        /// Relavant StackOverflow Post: http://stackoverflow.com/questions/926227/how-to-detect-if-machine-is-joined-to-domain-in-c
        /// </summary>
        /// <seealso cref="GetComputerDomainName"/>
        /// <returns>Domain name if user is connected to a domain, String.Empty if not.</returns>
        static string GetUserDomainName()
        {
            string domain = String.Empty;
            try
            {
                domain = Environment.UserDomainName;
                string machineName = Environment.MachineName;
                if (machineName.Equals(domain))
                {
                    domain = String.Empty;
                }
            }
            catch
            {
                // Handle exception if desired, otherwise returns null
            }
            return domain;
        }
        /// <summary>
        /// Returns the Domain which the computer is joined to.  Note: if user is logged in as local account the domain of computer is still returned!
        /// </summary>
        /// <seealso cref="GetUserDomainName"/>
        /// <returns>A string with the domain name if it's joined.  String.Empty if it isn't.</returns>
        static string GetComputerDomainName()
        {
            string domain = String.Empty;
            try
            {
                domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;
            }
            catch
            {
                // Handle exception here if desired.
            }
            return domain;
        }
