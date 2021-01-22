    using System;
    using OutLook = Microsoft.Office.Interop.Outlook;
    
    class OutlookFolders
    {
        OutLook.Application outlookObj = new OutLook.Application();
        public OutlookFolders()
        {
            foreach (OutLook.MAPIFolder folder in outlookObj.Session.Folders)
            {
                Console.WriteLine(folder.Name);
            }
        }
    }
