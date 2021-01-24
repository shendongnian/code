    public static SecurityIdentifier usernameToSid(string user)
    {
        if (user.StartsWith(@".\"))
        {
            user = user.Replace(@".\", Environment.MachineName + @"\");
        }
        
        NTAccount account = new NTAccount(user);
        return (SecurityIdentifier)account.Translate(typeof(SecurityIdentifier));
    }
