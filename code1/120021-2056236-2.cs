    using System.Runtime.InteropServices;
    using OutLook = Microsoft.Office.Interop.Outlook;
    using Office = Microsoft.Office.Core;
    
        OutLook.Application oApp;
                 OutLook._NameSpace oNS;
                 OutLook.MAPIFolder oFolder;
                 OutLook._Explorer oExp;
        
                 oApp = new OutLook.Application();
                 oNS = (OutLook._NameSpace)oApp.GetNamespace("MAPI");
                 oFolder = oNS.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
                 oExp = oFolder.GetExplorer(false);
                 oNS.Logon(Missing.Value, Missing.Value, false, true);
        
            OutLook.Items items = oFolder.Items;
            foreach (OutLook.MailItem mail in items)
                            {
                                
                                if (mail.UnRead == true)
                                {
                            }
            }
