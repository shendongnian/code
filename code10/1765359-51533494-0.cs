    using (var clientContext = new ClientContext(siteUrl))
                {
                    clientContext.Credentials = new SharePointOnlineCredentials(login, securePassword);
                    List myList = clientContext.Web.Lists.GetByTitle("MyTask");
    
                    ListItemCreationInformation listItemCreationInformation = new ListItemCreationInformation();
                    ListItem newItem = myList.AddItem(listItemCreationInformation);
                    newItem["Title"] = "subTask";
                    newItem["Body"] = "body";
                    FieldLookupValue lookupParent = new FieldLookupValue();
                    //hardcode for test purpose
                    lookupParent.LookupId = 3;
                    newItem["ParentID"] = lookupParent;
                    newItem.Update();
                    clientContext.ExecuteQuery();
    }
