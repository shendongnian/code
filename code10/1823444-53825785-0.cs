    private void ThisApplication_NewMail()
    {
        Outlook.MAPIFolder inBox = this.Application.ActiveExplorer()
            .Session.GetDefaultFolder(Outlook
            .OlDefaultFolders.olFolderInbox);
        Outlook.Items inBoxItems = inBox.Items;
        Outlook.MailItem newEmail = null;
        inBoxItems = inBoxItems.Restrict("[Unread] = true");
        try
        {
            foreach (object collectionItem in inBoxItems)
            {
                newEmail = collectionItem as Outlook.MailItem;
                if (newEmail != null)
                {
                    if (newEmail.Attachments.Count > 0)
                    {
                        for (int i = 1; i <= newEmail
                           .Attachments.Count; i++)
                        {
                            newEmail.Attachments[i].SaveAsFile
                                (@"C:\TestFileSave\" +
                                newEmail.Attachments[i].FileName);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string errorInfo = (string)ex.Message
                .Substring(0, 11);
            if (errorInfo == "Cannot save")
            {
                MessageBox.Show(@"Create Folder C:\TestFileSave");
            }
        }
    }
