    OutLook.Application oApp;
    OutLook._NameSpace oNS;
    OutLook.MAPIFolder oFolder;
    OutLook._Explorer oExp;
    oApp = new OutLook.Application();
    oNS = (OutLook._NameSpace)oApp.GetNamespace("MAPI");
    oFolder = oNS.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
    oExp = oFolder.GetExplorer(false);
    oNS.Logon(Missing.Value, Missing.Value, false, true);
    
    OutLook.Items items = oFolder.Items.Restrict("[Unread]=true");
    foreach (OutLook.MailItem mail in items)
    {
        if (mail.UnRead)
        {
            mail.UnRead = false;
            mail.Save();
        }
        Marshal.ReleaseCOMObject(mail);
    }
    Marshal.ReleaseCOMObject(items);
    // Dont forget to free all other object, using Marshal.ReleaseCOMObject then close oApp
