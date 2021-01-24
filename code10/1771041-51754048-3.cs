    public bool ValidateUser(string username, string password)
            {
                try
                {
    
                    var provider = Membership.Providers["UsersMembershipProvider"];     // from web.config 
    
                    if (provider != null)
                    {                                           
                        var validUser = provider.ValidateUser(username, password)
                            ? Task.FromResult(BackOfficeUserPasswordCheckerResult.ValidCredentials)
                            : Task.FromResult(BackOfficeUserPasswordCheckerResult.InvalidCredentials);
                        return validUser.Result == BackOfficeUserPasswordCheckerResult.ValidCredentials;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
