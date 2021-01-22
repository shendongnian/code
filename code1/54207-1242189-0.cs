    Outlook.Application olApp = new Outlook.Application();
        //mapifolder for earlier versions (such as ol 2003)
        Outlook.Folder contacts = olApp.Session.GetDefaultFolder(Outlook.olDefaultFolders.olFolderContacts);
        //must start with IPM.   & must be derived from a base item type, in this case contactItem.
        Outlook.ContactItem itm = (Outlook.ContactItem)contacts.Items.Add(@"IPM.Contact.CustomMessageClass");
        itm.Display(false);
