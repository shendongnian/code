        Microsoft.Office.Interop.Outlook.MAPIFolder folderDrafts = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderDrafts);
        if (folderDrafts.Items.Count > 0)
        {
            m = (Microsoft.Office.Interop.Outlook.MailItem)folderDrafts.Items[1];
            Recipient r = m.Recipients.Add("joe.bloggs");
            r.Type = (int)OlMailRecipientType.olBCC;
            m.Display(true);
        }
