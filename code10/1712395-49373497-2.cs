    var permissionCache = new Dictionary<User, bool>();
    foreach (var request in requestsList) {
        foreach (var myVar in request.anotherList) {
            bool permission;
            if (!permissionCache.TryGetValue(myVar, out permission)) {
                permission = myVar.hasPermissions();
                permissionCache.Add(myVar, permission);
            }
            if (permission) {
                //do something
            }
        }
    }
