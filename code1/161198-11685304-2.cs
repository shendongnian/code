        void CreateWithAttachment()
        {
            const string listName = "MyListName";
            // set up our credentials
            var credentials = new NetworkCredential("username", "password", "domain");
            // create a soap client
            var soapClient = new ListsService.Lists();
            soapClient.Credentials = credentials;
            // var create a client context
            var clientContext = new Microsoft.SharePoint.Client.ClientContext("https://my.sharepoint.installation/personal/test");
            clientContext.Credentials = credentials;
            // create a list item
            var list = clientContext.Web.Lists.GetByTitle(listName);
            var itemCreateInfo = new ListItemCreationInformation();
            var newItem = list.AddItem(itemCreateInfo);
            // set its properties
            newItem["Title"] = "Created from Client API";
            newItem["Status"] = "New";
            newItem["_Comments"] = "here are some comments!!";
            // commit it
            newItem.Update();
            clientContext.ExecuteQuery();
            // load back the created item so its ID field is available for use below
            clientContext.Load(newItem);
            clientContext.ExecuteQuery();
            // use the soap client to add the attachment
            const string path = @"c:\temp\test.txt";
            soapClient.AddAttachment(listName, newItem["ID"].ToString(), Path.GetFileName(path),
                                      System.IO.File.ReadAllBytes(path));
        }
