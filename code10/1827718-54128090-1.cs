    AddUserInRole("AdminApp", "AdminAppUser", @"SMO01\simon");
    
    ....
    static void AddUserInRole(string appName, string roleName, string userName)
    {
        dynamic catalog = Activator.CreateInstance(Type.GetTypeFromProgID("COMAdmin.COMAdminCatalog"));
        // the list of collection hierarchy : https://docs.microsoft.com/en-us/windows/desktop/cossdk/com--administration-collections
        var apps = catalog.GetCollection("Applications");
        var app = GetCollectionItem(apps, appName);
        if (app == null)
            throw new Exception("Application '" + appName + "' was not found.");
        var roles = apps.GetCollection("Roles", app.Key);
        var role = GetCollectionItem(roles, roleName);
        if (role == null)
            throw new Exception("Role '" + roleName + "' was not found.");
        // UsersInRole collection
        // https://docs.microsoft.com/en-us/windows/desktop/cossdk/usersinrole
        var users = roles.GetCollection("UsersInRole", role.Key);
        var user = GetCollectionItem(users, userName);
        if (user == null)
        {
            user = users.Add();
            user.Value["User"] = userName;
            users.SaveChanges();
        }
    }
    static dynamic GetCollectionItem(dynamic collection, string name)
    {
        collection.Populate();
        for (int i = 0; i < collection.Count; i++)
        {
            var item = collection.Item(i);
            if (item.Name == name)
                return item;
        }
        return null;
    }
    
