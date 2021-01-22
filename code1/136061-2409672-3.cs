    private void AddUsers(UserInfo userInfo, InfinityInfo infinityInfo, int subUserStart)
    {
        var userSerach = new UserPrincipal(context);
        userSerach.SamAccountName = userInfo.Username + '*';
        var ps = new PrincipalSearcher(userSerach);
        var pr = ps.FindAll().ToList().Where(a =>
                    Regex.IsMatch(a.SamAccountName, String.Format(@"{0}\D", userInfo.Username))).ToDictionary(a => a.SamAccountName); // removes results like conversons12 from the search conversions1*
        pr.Add(userInfo.Username, Principal.FindByIdentity(context, IdentityType.SamAccountName, userInfo.Username));
        using (GroupPrincipal r = GroupPrincipal.FindByIdentity(context, "Remote Desktop Users"))
        using (GroupPrincipal u = GroupPrincipal.FindByIdentity(context, "Users"))
        for(int i = subUserStart; i < userInfo.SubUsers; ++i)
        {
            string username = userInfo.Username;
            if (i >= 0)
            {
                username += (char)('a' + i);
            }
            UserPrincipal user = null;
            try
            {
                if (userInfo.NewPassword == null)
                    throw new ArgumentNullException("userInfo.NewPassword", "userInfo.NewPassword was null");
                if (userInfo.NewPassword == "")
                    throw new ArgumentOutOfRangeException("userInfo.NewPassword", "userInfo.NewPassword was empty");
                if (pr.ContainsKey(username))
                {
                    user = (UserPrincipal)pr[username];
                    user.Enabled = true;
                    user.SetPassword(userInfo.NewPassword);
                }
                else
                {
                    user = new UserPrincipal(context, username, userInfo.NewPassword, true);
                    user.UserCannotChangePassword = true;
                    user.PasswordNeverExpires = true;
                    user.Save();
                    r.Members.Add(user);
                    u.Members.Add(user);
                    r.Save();
                    u.Save();
                }
                IADsTSUserEx iad = (IADsTSUserEx)((DirectoryEntry)user.GetUnderlyingObject()).NativeObject;
                iad.TerminalServicesInitialProgram = GenerateProgramString(infinityInfo);
                iad.TerminalServicesWorkDirectory = Service.Properties.Settings.Default.StartInPath;
                iad.ConnectClientDrivesAtLogon = 0;
                user.Save();
                OperationContext.Current.GetCallbackChannel<IRemoteUserManagerCallback>().FinishedChangingUser(username);
            }
            finally
            {
                if (user != null)
                {
                    user.Dispose();
                }
            }
        }
    }
