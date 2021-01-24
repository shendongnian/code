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
    // Switched to for, https://stackoverflow.com/questions/4317850/do-i-need-to-release-the-com-object-on-every-foreach-iteration#4317878
    for (int i = items.Count; i >= 1; i--)
    {
         var mail = items[i];
         if (mail.UnRead)
         {
              mail.UnRead = false;
              mail.Save();
         }
         Marshal.ReleaseComObject(mail);
     }
     Marshal.ReleaseComObject(items);
