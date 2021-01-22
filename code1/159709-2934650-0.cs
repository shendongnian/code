    public bool IsUserAuthorizedToSignIn(string userEMailAddress, string userPassword)
        {
            try
            {
                // get MD5 hash for use in the LINQ query
                string passwordSaltedHash = this.PasswordSaltedHash(userEMailAddress, userPassword);
                // check for email / password / validity
                using (UserManagementDataContext context = new UserManagementDataContext())
                {
                    var users = from u in context.Users
                            where u.UserEMailAdresses.Any(e => e.EMailAddress == userEMailAddress)
                                && u.UserPasswords.Any(p => p.PasswordSaltedHash == passwordSaltedHash)
                                && u.IsActive == true
                            select u;
                    // true if user found
                    return (users.Count() == 1) ? true : false;
                }
            }
            catch(ThisException e)
            {
                thrown new AuthorisationException("Problem1 occurred");
            }
            catch(ThatException e)
            {
                thrown new AuthorisationException("Problem2 occurred");
            }
            catch(OtherException e)
            {
                thrown new AuthorisationException("Problem3 occurred");
            }
        }
