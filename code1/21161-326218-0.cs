    SPFieldUserValue usersField = new SPFieldUserValue(mainWeb, item["Users"].ToString());
    bool isUser = SPUtility.IsLoginValid(site, usersField.User.LoginName);
    List<SPUser> users = new List<SPUser>();
    if (isUser)
    {
        // add a single user to the list
        users.Add(usersField.User);
    }
    else
    {
        SPGroup group = web.Groups.GetByID(usersField.LookupId);
        foreach (SPUser user in group.Users)
        {
            // add all the group users to the list
            users.Add(user.User);
        }
    }
