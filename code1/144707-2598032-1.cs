                 using (_site = new SPSite("http:\\MySite")) //Disposing correctly to prevent memory leaks
                 using (_web = _site.OpenWeb())
                 {
                     try {
                       list = _web.Lists[sListName]; //SPException may be thrown if sListName does not exist
                       _web.AllowUnsafeUpdates = true;
                       items = list.Items;
                       item = items.Add(); //Before doing this, check if you have permissions with list.DoesUserHavePermissions to add items to prevent exception here
                       item["Title"] = "new Title";
                       item["UserName"] = CurrentUser.ToString(); //Not sure which, but some exception may be thrown if such field does not exist and ArgumentNullException may be thrown if CurrentUser is null
                       item["Configuration"] = sConfiguration.ToString(); //ArgumentNullException may be thrown
                       item.Update();
                     }
                     finally {
                       _web.AllowUnsafeUpdates = false;
                     }
                 }
