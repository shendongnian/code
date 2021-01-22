    public static Guid? LoggedInUserGuid()
            {
                var loggedInUser = Membership.GetUser(false);
                if (loggedInUser != null)
                {
                    return (Guid)Membership.GetUser(false).ProviderUserKey;
                }
    
                return null;
            }
