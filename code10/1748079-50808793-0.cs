    Object obj = new Object();
        Parallel.ForEach(userlist, (usr) =>
        {
            userandGroup usrgp = new userandGroup();
            usrgp.id = ((Guid)usr.ProviderUserKey).ToString();
            usrgp.Name = usr.UserName;
            ProfileBase profile = ProfileBase.Create(usr.UserName);
            profile.Initialize(usr.UserName, true);
            usrgp.type = "user";
            usrgp.DisplayName = profile.GetPropertyValue("FirstName").ToString() + " " + profile.GetPropertyValue("LastName").ToString();
            lock (obj)
            {                
                lst.Add(usrgp);
            }
        });
