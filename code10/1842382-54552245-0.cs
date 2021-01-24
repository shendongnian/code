        /// <summary>
        ///     Validate username and password combination    
        ///     <para>Following Windows Services must be up</para>
        ///     <para>LanmanServer; TCP/IP NetBIOS Helper</para>
        /// </summary>
        /// <param name="userName">
        ///     Fully formatted UserName.
        ///     In AD: Domain + Username
        ///     In Workgroup: Username or Local computer name + Username
        /// </param>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static bool ValidateUsernameAndPassword(string userName, SecureString securePassword)
        {
            bool result = false;
            ContextType contextType = ContextType.Machine;
            if (InDomain())
            {
                contextType = ContextType.Domain;
            }
            try
            {
                using (PrincipalContext principalContext = new PrincipalContext(contextType))
                {
                    result = principalContext.ValidateCredentials(
                        userName, 
                        new NetworkCredential(string.Empty, securePassword).Password
                    );
                }
            }
            catch (PrincipalOperationException)
            {
                // Account disabled? Considering as Login failed
                result = false;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
