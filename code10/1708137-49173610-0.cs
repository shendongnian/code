    static void ReadMail(){
        Microsoft.Office.Interop.Outlook.Application app = null;
        Microsoft.Office.Interop.Outlook._NameSpace ns = null;
        Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
        app = new Microsoft.Office.Interop.Outlook.Application();
        ns = app.GetNamespace("MAPI");
        inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        Outlook.Items Items = inboxFolder.Items.Restrict(""[LastModificationTime] > '01/1/2003'");
        foreach (var item in Items){
            var mail = (Outlook.MailItem)item;
            mail.Body = mail.Body.Replace("Text to be replaced", "Replacing text");
            mail.Save();
        }
              
    }
