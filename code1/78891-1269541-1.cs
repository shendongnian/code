    using System;
    using OutLook = Microsoft.Office.Interop.Outlook;
    
    class OutlookFolders
    {
        static void Main(string[] args)
        {
            OutLook.Application outlookObj = new OutLook.Application();
            GetSubFolders(outlookObj.Session.Folders);
        }
        private static void GetSubFolders(OutLook.Folders folders)
        {
            foreach (OutLook.MAPIFolder f in folders)
            {
                Console.WriteLine(f.Name);
                GetSubFolders(f.Folders);
            }
        }
    }
